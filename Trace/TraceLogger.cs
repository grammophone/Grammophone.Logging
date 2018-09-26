using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.Trace
{
	/// <summary>
	/// Logger which outputs entries using <see cref="System.Diagnostics.Trace"/>.
	/// </summary>
	public class TraceLogger : ILogger
	{
		#region Construction

		internal TraceLogger()
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Write an entry to the registered trace writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.</param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.
		/// </param>
		public void Log(LogLevel logLevel, string message, params object[] arguments)
		{
			string formattedMessage = FormatMessage(logLevel, message, arguments);

			LogFormattedMessage(logLevel, formattedMessage);
		}

		/// <summary>
		/// Write an entry to the registered trace listeners.
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
			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine(FormatMessage(logLevel, message, arguments));

			stringBuilder.AppendLine("Exception:");

			stringBuilder.Append(FormatException(exception));

			string formattedMessage = stringBuilder.ToString();

			LogFormattedMessage(logLevel, formattedMessage);
		}

		/// <summary>
		/// Write an entry to the registered trace listeners.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			string formattedMessage = FormatMessage(logLevel, message, arguments);

			LogFormattedMessage(logLevel, formattedMessage);
		}

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
		public void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments)
		{
			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine(FormatMessage(logLevel, formatProvider, message, arguments));

			stringBuilder.AppendLine("Exception:");

			stringBuilder.Append(FormatException(exception));

			string formattedMessage = stringBuilder.ToString();

			LogFormattedMessage(logLevel, formattedMessage);
		}

		#endregion

		#region Private methods

		private void LogFormattedMessage(LogLevel logLevel, string formattedMessage)
		{
			switch (logLevel)
			{
				case LogLevel.Info:
					System.Diagnostics.Trace.TraceInformation(formattedMessage);
					break;

				case LogLevel.Warn:
					System.Diagnostics.Trace.TraceWarning(formattedMessage);
					break;

				case LogLevel.Fatal:
				case LogLevel.Error:
					System.Diagnostics.Trace.TraceError(formattedMessage);
					break;

				default:
					System.Diagnostics.Trace.Write(formattedMessage);
					break;
			}
		}

		private string FormatMessage(LogLevel logLevel, string message, object[] arguments)
		{
			if (message == null) throw new ArgumentNullException(nameof(message));

			return $"{logLevel}: {String.Format(message, arguments)}";
		}

		private string FormatMessage(LogLevel logLevel, IFormatProvider formatProvider, string message, object[] arguments)
		{
			if (message == null) throw new ArgumentNullException(nameof(message));

			return $"{logLevel}: {String.Format(formatProvider, message, arguments)}";
		}

		private string FormatException(Exception exception)
		{
			if (exception == null) throw new ArgumentNullException(nameof(exception));

			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine($"Exception type '{exception.GetType().FullName}' message: '{exception.Message}'");

			if (exception is AggregateException aggregateException)
			{
				var flattenedAggregateExeption = aggregateException.Flatten();

				for (int i = 0; i < flattenedAggregateExeption.InnerExceptions.Count; i++)
				{
					stringBuilder.AppendLine($"Aggregate exception #{i}:");

					stringBuilder.Append(FormatException(flattenedAggregateExeption.InnerExceptions[i]));
				}
			}
			else if (exception.InnerException != null)
			{
				stringBuilder.AppendLine("Inner exception:");

				stringBuilder.Append(FormatException(exception.InnerException));
			}

			return stringBuilder.ToString();
		}

		#endregion
	}
}
