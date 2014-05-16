using System;
using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		playersEnded = new bool[ControllerManager.Get().GetControllers().Count];
		started = false;
		ended = false;
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
			if (started)
			{

			}
		}
	}

	static void Unload()
	{
		foreach (SectorData sd in currentLevel.Sectors)
		{
			UnityEngine.Object.Destroy(sd.SpawnModule);
			for (int i = 0; i < sd.SectorModules.Count; i++)
			{
				Module m = sd.SectorModules[i];

				UnityEngine.Object.Destroy(m);
			}
			UnityEngine.Object.Destroy(sd.FightingModule);
		}
	}

	/// <summary>
	/// Set the next sector to be spawned in - automatically removes all spawned chars.
	/// </summary>
	static void NextSector(SectorData next)
	{
		currentSector = next;
	}

	/// <summary>
	/// Spawns in the first module of this level.
	/// </summary>
	static void SpawnFirst()
	{
		sectorNumber = 0;

		NextSector(currentLevel.Sectors[sectorNumber]);

		Spawn(false);
		
		TakeControl();
	}

	/// <summary>
	/// Spawns in the current sectors spawn module.
	/// </summary>
	static void Spawn(bool fighting)
	{
		DoSpawn((fighting) ? currentSector.FightingModule : currentSector.SpawnModule);
	}

	/// <summary>
	/// Spawn in the specified module.
	/// </summary>
	/// <param name="module">The Module to spawn in.</param>
	static void DoSpawn(SpawnModule module)
	{
		List<int> spawns = new List<int>(new int[] {0, 0, 0});

		int maxSpawns = Mathf.Min(2, ControllerManager.Get().GetControllers().Count);

		for (int i = 0; i < maxSpawns; i++)
		{
			// Pick a random spawn point (or what is remaining)
			int pick = spawns [Util.Randomizer.Next(spawns.Count)];
			ICharacter[] charTypes;
			
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


			ICharacter character;
			// Spawn a random char 
			spawnedCharacters.Add(character = module.Spawns[pick].DoSpawn(i, charTypes [Util.Randomizer.Next(charTypes.Length)]));

			Debug.Log("Spawned character " + character.name + " in sector " + currentSector.Name + " in module " + module.name + " for player " + i);

			// remove spawn point from list
			spawns.Remove(pick);
		}
	}
	
	/// <summary>
	/// Dos the despawning.
	/// </summary>
	/// <param name="character">Character.</param>
	public static void DoDespawn(ICharacter character)
	{
		if (spawnedCharacters != null &&
			spawnedCharacters.Contains(character))
		{
			Player p = character.GetOwningPlayer();
			spawnedCharacters.Remove(character);
			CharacterManager.Get().UnregisterCharacter(p.PlayerIndex);
			
			PlayerEndedSector(p);


		}
	}

	/// <summary>
	/// Makes the palyers take the control of thier characters.
	/// </summary>
	static void TakeControl()
	{		
		foreach (ICharacter c in spawnedCharacters)
		{
			PlayerManager.Get().GetPlayer(c.GetOwningPlayer().PlayerIndex).GetController().UseCharacter(c);
		}
		started = true;
	}

	/// <summary>
	/// Called if a player ends a sector.
	/// </summary>
	/// <param name="p">The player</param>
	static void PlayerEndedSector(Player p)
	{		
		sectorNumber++;

		// if we reach the last despawn
		if (sectorNumber == currentLevel.Sectors.Count)
		{
			PlayerEndedLevel(p);
			return;
		}
		
		NextSector(currentLevel.Sectors [sectorNumber]);
		
		Spawn(false);
		
		TakeControl();
	}
	
	/// <summary>
	/// Called if a player ends a level.
	/// </summary>
	/// <param name="p">The player</param>
	static void PlayerEndedLevel(Player p)
	{
		playersEnded [p.PlayerIndex] = true;
		
		Debug.Log("Level ended by player " + p.PlayerIndex);
		
		ended = true;
		foreach (bool b in playersEnded)
		{
			if (!b)
			{
				ended = false;
			}
		}
		
		if (ended)
		{
			LevelEnded();
		}
	}
	
	/// <summary>
	/// Called if both players ended the level.
	/// </summary>
	static void LevelEnded()
	{
		Debug.Log("Level ended by both players!");

		Unload();

		GamestateManager.Get().ChangeState(GamestateType.MainMenu);
	}

	/// <summary>
	/// Respawn in the specified sector at the first module.
	/// </summary>
	/// <param name="sector">Sector.</param>
	static void Respawn(int sector)
	{
		DoSpawn(currentLevel.Sectors [sector].SpawnModule);
	}
    
	////////////////////////////////////////////////////////////////////

	static public float GetLevelProgress(ICharacter character)
	{
		if (CurrentLevel != null 
			&& spawnedCharacters.Contains(character))
		{
			float length = Mathf.Abs(
				currentLevel.Sectors [0].SpawnModule.InConnector.transform.position.x - 
				currentLevel.Sectors [currentLevel.Sectors.Count - 1].FightingModule.OutConnector.transform.position.x);
	
			if (length != 0)
			{
				float progress = Mathf.Abs(currentLevel.Sectors [0].SpawnModule.InConnector.transform.position.x - 
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
			float length = Vector3.Distance(currentLevel.Sectors [0].SpawnModule.InConnector.transform.position, 
			                                currentLevel.Sectors [currentLevel.Sectors.Count - 1].FightingModule.OutConnector.transform.position);

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

	// progress logic

	static int sectorNumber = 0;
	static bool[] playersEnded;
	static bool started;
	static bool ended;

	////////////////////////////////////////////////////////////////////

	// current loaded level, sector and chars

	static LevelData currentLevel;
	static SectorData currentSector;
	static List<ICharacter> spawnedCharacters = new List<ICharacter>();


}

