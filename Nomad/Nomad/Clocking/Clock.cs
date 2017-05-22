using Nomad.Exception.Clocking;
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
		public const double MAX_TICKS_PER_SECOND = 120;

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

		public bool IsPlaying { get { return !this._isPaused; } }

		private double _startTime;
		public double StartTime { get { return this._startTime; } }

		private long _totalTicksElapsed;
		public long TotalTicksElapsed { get { return this._totalTicksElapsed; } }
		
		public double AvgTicksPerSecond { get { return this.CalculateAverageTicksPerSecond(); } }

		private double _totalMSElapsed;
		public double TotalMSElapsed { get { return this._totalMSElapsed; } }

		#region Constructors

		public Clock(double ticksPerSecond)
		{
			if (ticksPerSecond > MAX_TICKS_PER_SECOND)
			{
				throw new ClockTickLimitException(ticksPerSecond);
			}

			TICKS_PER_SECOND = ticksPerSecond;
			MS_PER_TICK = 1000 / TICKS_PER_SECOND;
		}

		#endregion

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

			this._startTime = previous;

			double accumulated = 0.0;

			while (this.IsTicking)
			{
				if (this.IsPlaying)
				{
					double current = GetCurrentTimeMS();

					double elapsed = current - previous;

					this._totalMSElapsed += elapsed;
					accumulated += elapsed;

					previous = current;

					while (accumulated >= MS_PER_TICK)
					{
						++this._totalTicksElapsed;

						this.OnTick();

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
			if (this.IsPlaying)
			{
				throw new ClockAlreadyPlayingException();
			}

			this._isPaused = false;
		}

		/// <summary>
		/// Pauses the clock from ticking but retains elapsed time.
		/// </summary>
		/// <remarks>
		/// A paused clock can only be "started" again by using <see cref="Clock.Play"/>
		/// A paused clock is still considered to be ticking.
		/// </remarks>
		public void Pause()
		{
			if (this.IsPaused)
			{
				throw new ClockAlreadyPausedException();
			}

			this._isPaused = true;
		}

		#endregion

		#region Events

		public delegate void TickEventHandler(object source, EventArgs args);
		public event TickEventHandler TickEvent;
		protected virtual void OnTick()
		{
			Logger.Log(this.TotalMSElapsed);

			if (TickEvent != null)
				TickEvent(this, EventArgs.Empty);
		}

		#endregion

		private double CalculateAverageTicksPerSecond()
		{
			double totalSeconds = this.TotalMSElapsed / 1000;

			return (((double)this.TotalTicksElapsed) / totalSeconds);
		}
	}
}
