using Nomad.Clocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Exception.Clocking
{
	class ClockTickLimitException : ClockException
	{
		public ClockTickLimitException(double ticksPerSecond) 
			: base("The maximum number of ticks per second (" + Clock.MAX_TICKS_PER_SECOND + ") was reached: " + ticksPerSecond) { }
	}
}
