using System;
using UnityEngine;

public class Util
{
	public Util()
	{
	}

	public static System.Random Randomizer = new System.Random((int) (DateTime.Now.Ticks));

	public static System.Random RandomFromSeed(int seed)
	{
		return new System.Random(seed);
	}


	public class Timer
	{
		public delegate void OnLoop(float time, int loop);
		public delegate void OnComplete(float time, int loop);

		public Timer(float duration, int loop, bool instant)
		{
			this.duration = duration;
			this.loop = loop;
			started = false;
			ended = false;
			timeCreated = Time.realtimeSinceStartup;
			if (instant)
			{
				Start();
			}
		}

		public Timer(float duration, int loop, bool instant, OnComplete onComplete, OnLoop onLoop)
		{
			this.duration = duration;
			this.loop = loop;
			started = false;
			ended = false;
			timeCreated = Time.realtimeSinceStartup;
			onCompleteDelegate = onComplete;
			onLoopDelegate = onLoop;
			if (instant)
			{
				Start();
			}
		}

		public void Start()
		{
			started = true;
			ended = false;
			loopCounter = 0;
			timeStarted = Time.realtimeSinceStartup;
			timeEnded = 0;
		}

		public void Stop()
		{
			if (onCompleteDelegate != null)
			{
				onCompleteDelegate(Time.realtimeSinceStartup, loopCounter);
			}
			loopCounter = 0;
			timeEnded = Time.realtimeSinceStartup;
			ended = true;
		}

		public void Update()
		{
			if (started && !ended)
			{
				runningTime += Time.deltaTime;
				if (duration > -1 && runningTime > duration)
				{
					runningTime = 0;
					if (onLoopDelegate != null)
					{
						onLoopDelegate(Time.realtimeSinceStartup, ++loopCounter);
					}
					if (loop > -1 && loopCounter >= loop)
					{
						if (onCompleteDelegate != null)
						{
							onCompleteDelegate(Time.realtimeSinceStartup, loopCounter);
						}
						timeEnded = Time.realtimeSinceStartup;
						ended = true;
					}
				}
			}
		}

		public float RunningTime
		{
			get
			{
				return runningTime;
			}
		}

		public int LoopCounter
		{
			get
			{
				return loopCounter;
			}
		}

		public bool Started
		{
			get
			{
				return started;
			}
		}

		public bool Ended
		{
			get
			{
				return ended;
			}
		}

		public float TimeCreated
		{
			get
			{
				return timeCreated;
			}
		}

		public float TimeStarted
		{
			get
			{
				return timeStarted;
			}
		}

		public float TimeEnded
		{
			get
			{
				return timeEnded;
			}
		}

		float timeCreated;
		float timeStarted;
		float timeEnded;

		float runningTime;
		int loopCounter;

		float duration;
		int loop;

		bool started;
		bool ended;

		OnComplete onCompleteDelegate = null;
		OnLoop onLoopDelegate = null;
	}
}
