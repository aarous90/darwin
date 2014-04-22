using System;
using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		if (Generator != null)
		{
			Generator.Load(levelData = Generator.Generate(GeneratorSectorBowl));
			SpawnFirst();
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Generator.IsLevelGenerated && 
		    Generator.IsLevelLoaded)
		{
			
		}
	}

	/// <summary>
	/// Spawns in the first module of this level.
	/// </summary>
	void SpawnFirst()
	{
		Module first = levelData.Sectors[0].GenreatorModules[0];

		Spawn(first);
	}
	/// <summary>
	/// Spawn in the specified module.
	/// </summary>
	/// <param name="module">The Module to spawn in.</param>
	void Spawn(Module module)
	{
		List<int> spawns = new List<int>(new int[] {0, 1, 2});

		int maxSpawns = Mathf.Min(2, ControllerManager.Get().GetControllers().Count);

		for (int i = 0; i < maxSpawns; i++)
		{
			// Pick a random spawn point (or what is remaining)
			int pick = spawns[Util.Randomizer.Next(spawns.Count)];
			// get the available characters
			ICharacter[] charTypes = CharacterManager.Get().CharacterTypes;
			// Spawn a random char 
			// TODO: care about different terrain!
			module.Spawns[pick].DoSpawn(i, charTypes[Util.Randomizer.Next(charTypes.Length)]);
			// remove spawn point from list
			spawns.Remove(pick);
		}
	}

	/// <summary>
	/// Respawn in the specified sector at the first module.
	/// </summary>
	/// <param name="sector">Sector.</param>
	void Respawn(Sector sector)
	{
		Spawn(sector.Modules[0]);
	}
    
    ////////////////////////////////////////////////////////////////////
	
	public Sector[] GeneratorSectorBowl;

	public LevelGenerator Generator;

	////////////////////////////////////////////////////////////////////

	LevelData levelData;


}

