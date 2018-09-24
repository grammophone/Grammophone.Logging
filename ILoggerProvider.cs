using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging
{
	/// <summary>
	/// Interface to provide instances of <see cref="ILogger"/>.
	/// </summary>
	public interface ILoggerProvider
	{
		/// <summary>
		/// Get the logger registered under a specified name.
		/// </summary>
		/// <param name="loggerName">The name under which the logger is registered.</param>
		/// <returns>Returns the <see cref="ILogger"/> requested.</returns>
		ILogger GetLogger(string loggerName);
	}
}
