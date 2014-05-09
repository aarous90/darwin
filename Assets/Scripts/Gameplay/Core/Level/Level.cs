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
			Generator.Load(currentLevel = Generator.Generate(GeneratorSectorBowl));
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
	/// Set the next sector to be spawned in - automatically removes all spawned chars.
	/// </summary>
	public static void NextSector(SectorData next)
	{
		currentSector = next;
		spawnedCharacters.Clear();
	}

	/// <summary>
	/// Spawns in the first module of this level.
	/// </summary>
	void SpawnFirst()
	{
		NextSector(currentLevel.Sectors[0]);

		Spawn(false);
		
		TakeControl();
	}

	/// <summary>
	/// Spawns in the current sectors spawn module.
	/// </summary>
	void Spawn(bool fighting)
	{
		DoSpawn((fighting) ? currentSector.FightingModule : currentSector.SpawnModule);
	}

	/// <summary>
	/// Spawn in the specified module.
	/// </summary>
	/// <param name="module">The Module to spawn in.</param>
	void DoSpawn(SpawnModule module)
	{
		List<int> spawns = new List<int>(new int[] {0, 1, 2});

		int maxSpawns = Mathf.Min(2, ControllerManager.Get().GetControllers().Count);

		for (int i = 0; i < maxSpawns; i++)
		{
			// Pick a random spawn point (or what is remaining)
			int pick = spawns[Util.Randomizer.Next(spawns.Count)];
			ICharacter[] charTypes;// = CharacterManager.Get().CharacterTypes;
			
			// get the available characters
			switch (pick)
			{
				case 0:
					charTypes = CharacterManager.Get().AirCharacterTypes;
					break;
				case 1:
					charTypes = CharacterManager.Get().GroundCharacterTypes;
					break;
				case 2:
					charTypes = CharacterManager.Get().WaterCharacterTypes;
					break;
				default:
					throw new UnityException("Error while spawning character!");
			}

			// Spawn a random char 
			spawnedCharacters.Add(module.Spawns[pick].DoSpawn(i, charTypes[Util.Randomizer.Next(charTypes.Length)]));
			// remove spawn point from list
			spawns.Remove(pick);
		}
	}

	/// <summary>
	/// Makes the palyers take the control of thier characters.
	/// </summary>
	void TakeControl()
	{		
		foreach (ICharacter c in spawnedCharacters)
		{
			PlayerManager.Get().GetPlayer(c.GetOwningPlayer().PlayerIndex).GetController().UseCharacter(c);
		}
	}

	/// <summary>
	/// Respawn in the specified sector at the first module.
	/// </summary>
	/// <param name="sector">Sector.</param>
	void Respawn(int sector)
	{
		DoSpawn(currentLevel.Sectors[sector].SpawnModule);
	}
    
	////////////////////////////////////////////////////////////////////

	static public float GetLevelProgress(ICharacter character)
	{
		if (CurrentLevel != null 
		    && spawnedCharacters.Contains(character))
		{
			float length = Mathf.Abs(
				currentLevel.Sectors[0].SpawnModule.InConnector.transform.position.x - 
				currentLevel.Sectors[currentLevel.Sectors.Count-1].FightingModule.OutConnector.transform.position.x);
	
			if (length != 0)
			{
				float progress = Mathf.Abs(currentLevel.Sectors[0].SpawnModule.InConnector.transform.position.x - 
				                           character.transform.position.x);
				return (progress / length);
			}

		}
		return -1;
	}

	static public float GetSectorProgress(ICharacter character)
	{
		if (spawnedCharacters.Contains(character))
		{
			float length = Vector3.Distance(currentLevel.Sectors[0].SpawnModule.InConnector.transform.position, 
			                                currentLevel.Sectors[currentLevel.Sectors.Count-1].FightingModule.OutConnector.transform.position);

			if (length != 0)
			{
				float progress = Vector3.Distance(currentLevel.Sectors [0].SpawnModule.InConnector.transform.position, character.transform.position);
				return (progress / length);
			}
			
		}
		return -1;
	}

    ////////////////////////////////////////////////////////////////////
	
	public Sector[] GeneratorSectorBowl;

	public LevelGenerator Generator;

	public static LevelData CurrentLevel
	{
		get
		{
			return currentLevel;
		}
	}

	////////////////////////////////////////////////////////////////////

	static LevelData currentLevel;

	static SectorData currentSector;

	static List<ICharacter> spawnedCharacters = new List<ICharacter>();


}

