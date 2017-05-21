using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PhysWorld.PhysLogic
{
	/// <summary>
	/// Used to track the elapsing of game time.
	/// </summary>
	static class Clock
	{
		const long UPDATE_CAP = 10;

		private static long GetCurrentTimeMS()
		{
			return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}

		public static void Start()
		{
			double previous = GetCurrentTimeMS();

			double accumulated = 0.0;
			
			while (true)
			{
				double current = GetCurrentTimeMS();

				double elapsed = current - previous;

				accumulated += elapsed;

				previous = current;

				while (accumulated >= UPDATE_CAP)
				{
					LogicTick(UPDATE_CAP);

					accumulated -= UPDATE_CAP;
				}
			}
		}

		private static void LogicTick(double elapsed)
		{

		}

		private static void Render(double elapsed)
		{

		}
	}
}
