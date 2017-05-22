using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Exception.Clocking
{
	class ClockAlreadyPlayingException : ClockException
	{
		public ClockAlreadyPlayingException() 
			: base("The clock cannot be played while already playing.") { }
	}
}
