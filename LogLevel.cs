using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging
{
	/// <summary>
	/// The severity log level when recording a log entry via an <see cref="ILogger"/>.
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// Trace log level.
		/// </summary>
		Trace,

		/// <summary>
		/// Debug log level.
		/// </summary>
		Debug,

		/// <summary>
		/// Info log level.
		/// </summary>
		Info,

		/// <summary>
		/// Warning log level.
		/// </summary>
		Warn,

		/// <summary>
		/// Error log level.
		/// </summary>
		Error,

		/// <summary>
		/// Fatal log level.
		/// </summary>
		Fatal
	}
}
