using System;
using UnityEngine;

public class Util
{
	public Util()
	{
	}

	public static System.Random Randomizer = new System.Random((int) Time.realtimeSinceStartup);

	public static System.Random RandomFromSeed(int seed)
	{
		return new System.Random(seed);
	}
}
