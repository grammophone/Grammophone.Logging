using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Trace
{
	/// <summary>
	/// Provider for logger writing entries using <see cref="System.Diagnostics.Trace"/>.
	/// </summary>
	public class TraceLoggerProvider : ILoggerProvider
	{
		/// <summary>
		/// Create a <see cref="TraceLogger"/>. The parameter <paramref name="loggerName"/> is ignored.
		/// </summary>
		public ILogger CreateLogger(string loggerName) => new TraceLogger();
	}
}
