using System;
using UnityEngine;

public class SpawnModule : Module
{
	
	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	////////////////////////////////////////////////////////////////////

	public CharacterSpawn AirSpawn;

	public CharacterSpawn GroundSpawn;

	public CharacterSpawn WaterSpawn;

	public CharacterSpawn[] Spawns
	{
		get
		{
			if (spawns != null && spawns.Length == 3)
			{
				return spawns;
			}
			if (AirSpawn != null && GroundSpawn != null && WaterSpawn != null)
			{
				spawns = new CharacterSpawn[] { AirSpawn, GroundSpawn, WaterSpawn };
			}
			else
			{	
				throw new UnityException("Each module needs three spawns for air, ground and water!");
			}
			return spawns;
		}
	}

	////////////////////////////////////////////////////////////////////
	 
	CharacterSpawn[] spawns; 
}

