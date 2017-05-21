using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Nomad.Clocking
{
	/// <summary>
	/// Used to track the elapsing of game time.
	/// </summary>
	class Clock
	{
		public readonly double TICKS_PER_SECOND;
		public readonly double MS_PER_TICK;
		
		/// <summary>
		/// Determines whether this clock is currently attempting to tick.
		/// A clock is still considered to be ticking even when temporarily paused.
		/// </summary>
		private bool _isTicking;
		public bool IsTicking
		{
			get { return this._isTicking; }
		}

		private bool _isPaused;
		public bool IsPaused { get { return this._isPaused; } }

		private long _totalTicksElapsed;
		public long TotalTicksElapsed { get { return this._totalTicksElapsed; } }
		
		public int AvgTicksPerSecond { get { return this.CalculateAverageTicksPerSecond(); } }

		private double _totalMSElapsed;
		public double TotalMSElapsed { get { return this._totalMSElapsed; } }

		public Clock(double ticksPerSecond)
		{
			TICKS_PER_SECOND = ticksPerSecond;
			MS_PER_TICK = 1000 / TICKS_PER_SECOND;
		}

		private static long GetCurrentTimeMS()
		{
			return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}

		#region Ticking

		/// <summary>
		/// Starts the clock.
		/// </summary>
		/// <remarks>
		/// The clock ticks at a constant rate.
		/// </remarks>
		public void Start()
		{
			this._isTicking = true;

			double previous = GetCurrentTimeMS();

			double accumulated = 0.0;

			while (this.IsTicking)
			{
				if (this.IsPaused == false)
				{
					double current = GetCurrentTimeMS();

					double elapsed = current - previous;

					this._totalMSElapsed += elapsed;

					accumulated += elapsed;

					previous = current;

					while (accumulated >= MS_PER_TICK)
					{
						++this._totalTicksElapsed;

						this.LogicTick(MS_PER_TICK);

						accumulated -= MS_PER_TICK;
					}
				}
			}
		}

		public void Stop()
		{
			this.Reset();

			this._isTicking = false;
		}

		public void Reset()
		{
			this._isTicking = true;

			this._totalMSElapsed = 0.0;
			this._totalTicksElapsed = 0;
		}

		public void Play()
		{
			this._isPaused = false;
		}

		/// <summary>
		/// Pauses the clock from ticking but retains elapsed time.
		/// </summary>
		/// <remarks>
		/// A paused clock can only be "started" again by using <see cref="Clock.Play"/>
		/// </remarks>
		public void Pause()
		{
			this._isPaused = true;
		}

		private void LogicTick(double elapsed)
		{

		}

		#endregion

		private int CalculateAverageTicksPerSecond()
		{
			int totalSeconds = (int)this.TotalMSElapsed / 1000;

			return (int)(this.TotalTicksElapsed / totalSeconds);
		}
	}
}
