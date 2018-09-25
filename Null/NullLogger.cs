using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Null
{
	/// <summary>
	/// An <see cref="ILogger"/> implementation doing nothing.
	/// </summary>
	public class NullLogger : ILogger
	{
		/// <summary>
		/// Does nothing.
		/// </summary>
		public void Log(LogLevel logLevel, string message, params object[] arguments)
		{
		}

		/// <summary>
		/// Does nothing.
		/// </summary>
		public void Log(LogLevel logLevel, Exception exception, string message, params object[] arguments)
		{
		}

		/// <summary>
		/// Does nothing.
		/// </summary>
		public void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments)
		{
		}

		/// <summary>
		/// Does nothing.
		/// </summary>
		public void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments)
		{
		}
	}
}
