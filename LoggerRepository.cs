using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammophone.Caching;

namespace Grammophone.Logging
{
	/// <summary>
	/// Repository for obtaining loggers using an underlying <see cref="ILoggerProvider"/>.
	/// The most frequently used loggers are cached.
	/// </summary>
	public class LoggerRepository
	{
		#region Private fields

		private readonly MRUCache<string, ILogger> loggersByNameCache;

		private readonly ILoggerProvider loggerProvider;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="loggerProvider">The provider used to create the requested loggers.</param>
		/// <param name="cacheSize">The size of the cache holding the most frequently used loggers.</param>
		public LoggerRepository(ILoggerProvider loggerProvider, int cacheSize = 4096)
		{
			if (loggerProvider == null) throw new ArgumentNullException(nameof(loggerProvider));

			this.loggerProvider = loggerProvider;
			this.loggersByNameCache = new MRUCache<string, ILogger>(this.loggerProvider.CreateLogger, cacheSize);
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Get the logger registered under a specified name.
		/// </summary>
		/// <param name="loggerName">The name under which the logger is registered.</param>
		/// <returns>Returns the <see cref="ILogger"/> requested.</returns>
		/// <remarks>
		/// Uses caching to return frequently requested loggers.
		/// The cache size is specified in the constructor of <see cref="LoggerRepository"/>.
		/// </remarks>
		public ILogger GetLogger(string loggerName) => loggersByNameCache.Get(loggerName);

		#endregion
	}
}
