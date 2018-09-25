using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Null
{
	/// <summary>
	/// Provider for <see cref="NullLogger"/>.
	/// </summary>
	public class NullLoggerProvider : ILoggerProvider
	{
		/// <summary>
		/// Creates a <see cref="NullLogger"/> irrespective of <paramref name="loggerName"/>.
		/// </summary>
		/// <returns>Returns a new <see cref="NullLogger"/>.</returns>
		public ILogger CreateLogger(string loggerName) => new NullLogger();
	}
}
