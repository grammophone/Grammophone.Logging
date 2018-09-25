using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging
{
	/// <summary>
	/// Interface for writing entries to the configured log writers.
	/// Implementations must be thread safe.
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.</param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.
		/// </param>
		void Log(LogLevel logLevel, string message, params object[] arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		void Log(LogLevel logLevel, Exception exception, string message, params object[] arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments);
	}
}
