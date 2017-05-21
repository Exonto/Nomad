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
		const double UPDATE_CAP = 10.0;

		private static long GetCurrentTimeMS()
		{
			return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}

		/// <summary>
		/// Starts the game clock.
		/// </summary>
		/// <remarks>
		/// The clock ticks at a constant rate.
		/// </remarks>
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
