using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Composite
{
	/// <summary>
	/// A logger logger provider which aggregates other logger providers
	/// into producing <see cref="CompositeLogger"/>.
	/// </summary>
	public class CompositeLoggerProvider : ILoggerProvider
	{
		#region Private fields

		private readonly ILoggerProvider[] aggregatedLogerProviders;

		#endregion

		#region Public properties

		/// <summary>
		/// The aggregated logger providers.
		/// </summary>
		public IReadOnlyCollection<ILoggerProvider> AggregatedLoggerProviders => aggregatedLogerProviders;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="aggregatedLogerProviders">The aggregated logger providers.</param>
		public CompositeLoggerProvider(ILoggerProvider[] aggregatedLogerProviders)
		{
			if (aggregatedLogerProviders == null) throw new ArgumentNullException(nameof(aggregatedLogerProviders));

			this.aggregatedLogerProviders = aggregatedLogerProviders;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Create a <see cref="CompositeLogger"/> by invoking <see cref="ILoggerProvider.CreateLogger(string)"/>
		/// on each of the provider in <see cref="AggregatedLoggerProviders"/>.
		/// </summary>
		/// <param name="loggerName">The name of the logger requested by each provider in <see cref="AggregatedLoggerProviders"/>.</param>
		/// <returns>Returns the requested <see cref="CompositeLogger"/>.</returns>
		public ILogger CreateLogger(string loggerName)
		{
			if (loggerName == null) throw new ArgumentNullException(nameof(loggerName));

			var aggregatedLoggers = new ILogger[aggregatedLogerProviders.Length];

			for (int i = 0; i < aggregatedLogerProviders.Length; i++)
			{
				aggregatedLoggers[i] = aggregatedLogerProviders[i].CreateLogger(loggerName);
			}

			return new CompositeLogger(aggregatedLoggers);
		}

		#endregion
	}
}
