using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Exception.Clocking
{
	/// <summary>
	/// Thrown when an error occurs during a clock operation.
	/// </summary>
	class ClockException : System.Exception
	{
		public ClockException()
			: base() { }

		public ClockException(string message)
			: base(message) { }

		public ClockException(string format, params object[] args)
			: base(string.Format(format, args)) { }

		public ClockException(string message, System.Exception innerException)
			: base(message, innerException) { }

		public ClockException(string format, System.Exception innerException, params object[] args)
			: base(string.Format(format, args), innerException) { }
	}
}
