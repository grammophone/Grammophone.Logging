using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Composite
{
	/// <summary>
	/// A logger which composes several loggers into one.
	/// </summary>
	public class CompositeLogger : ILogger
	{
		#region Private fields

		private readonly ILogger[] aggregatedLoggers;

		#endregion

		#region Construction

		internal CompositeLogger(ILogger[] aggregatedLoggers)
		{
			if (aggregatedLoggers == null) throw new ArgumentNullException(nameof(aggregatedLoggers));

			this.aggregatedLoggers = aggregatedLoggers;
		}

		#endregion

		#region Public properties

		/// <summary>
		/// The aggregated loggers.
		/// </summary>
		public IReadOnlyCollection<ILogger> AggregatedLoggers { get; }

		#endregion

		#region Public methods

		/// <summary>
		/// Write an entry to the <see cref="AggregatedLoggers"/>.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.</param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.
		/// </param>
		public void Log(LogLevel logLevel, string message, params object[] arguments)
		{
			for (int i = 0; i < aggregatedLoggers.Length; i++)
			{
				aggregatedLoggers[i].Log(logLevel, message, arguments);
			}
		}

		/// <summary>
		/// Write an entry to the <see cref="AggregatedLoggers"/>.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, Exception exception, string message, params object[] arguments)
		{
			for (int i = 0; i < aggregatedLoggers.Length; i++)
			{
				aggregatedLoggers[i].Log(logLevel, exception, message, arguments);
			}
		}

		/// <summary>
		/// Write an entry to the <see cref="AggregatedLoggers"/>.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			for (int i = 0; i < aggregatedLoggers.Length; i++)
			{
				aggregatedLoggers[i].Log(logLevel, formatProvider, message, arguments);
			}
		}

		/// <summary>
		/// Write an entry to the <see cref="AggregatedLoggers"/>.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			for (int i = 0; i < aggregatedLoggers.Length; i++)
			{
				aggregatedLoggers[i].Log(logLevel, exception, formatProvider, message, arguments);
			}
		}

		#endregion
	}
}
