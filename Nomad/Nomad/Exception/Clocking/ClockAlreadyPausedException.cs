using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Exception.Clocking
{
	class ClockAlreadyPausedException : ClockException
	{
		public ClockAlreadyPausedException() 
			: base("The clock cannot be paused while already being paused.") { }
	}
}
