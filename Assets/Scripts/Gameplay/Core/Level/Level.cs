using System;
using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		int playerCount = ControllerManager.Get().MaximumUsable;
		playersEnded = new bool[playerCount];
		sectorNumber = new int[playerCount];
		currentSectors = new SectorData[playerCount];
		started = false;
		ended = false;
		if (Generator != null)
		{
			Generator.Load(currentLevel = Generator.Generate(GeneratorSectorBowl));
			InitialCreate();
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
	/// Spawns in the first module of this level.
	/// </summary>
	static void InitialCreate()
	{
		for (int i = 0; i < sectorNumber.Length; i++)
		{
			sectorNumber[i] = 0;
		}

		int maxSpawns = Mathf.Min(2, ControllerManager.Get().MaximumUsable);
		
		for (int i = 0; i < maxSpawns; i++)
		{
			Player p = PlayerManager.Get().GetPlayer(i);
			PlayerNextSector(currentLevel.Sectors[0], p);
			ICharacter c = Create(p);
			UseCharacter(p, c);
			CharacterSpawn spawner = currentSectors[p.PlayerIndex].SpawnModule.Spawns[(int) c.CharacterType];
			c.Spawn(spawner);
		}

		started = true;
	}

	/// <summary>
	/// Spawns in the current sectors spawn module.
	/// </summary>
	static ICharacter Create(Player player)
	{
		return CreateCharacter(currentSectors[player.PlayerIndex], player);
	}

	/// <summary>
	/// Spawn in the specified module.
	/// </summary>
	/// <param name="module">The Module to spawn in.</param>
	static ICharacter CreateCharacter(SectorData sector, Player player)
	{
		// Pick a random spawn point (or what is remaining)
		// TODO: this is unfair, because the second player cannot pick out of 3 spawns
		int pick;
		int pref = LevelSettings.PreferedLayer[player.PlayerIndex];
		if (pref > -1 && pref < 3)
		{
			pick = pref;
		}
		else
		{
			pick = sector.SpawnsUnused[Util.Randomizer.Next(sector.SpawnsUnused.Count)];
		}

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
			{
				Debug.LogError("Error while spawning character!");
				return null;
			}
		}

		ICharacter character;
		// Spawn a random char for the player
		character = InstantiateCharacter(player, charTypes[Util.Randomizer.Next(charTypes.Length)]);		

		character.DecayEvent += new OnDecayHandler(OnCharacterDecay);

		Debug.Log("Spawned character " + character.name + " in sector " + currentSectors[player.PlayerIndex].Name + " in module " + sector.SpawnModule.name + " for player " + player.PlayerName + " (" + player.PlayerIndex + ")");

		// remove spawn point from list
		sector.SpawnsUnused.Remove(pick);

		return character;
	}

	
	public static ICharacter InstantiateCharacter(Player player, ICharacter character)
	{
		if (PlayerManager.Get().GetPlayer(player.PlayerIndex) != null)
		{
			ICharacter spawned;
			if ((spawned = character.Create(player)) != null)
			{
				return spawned;
			}
		}
		return null;
	}

	/// <summary>
	/// Dos the deletion of characters if they reached a secor ending (genmanipulator).
	/// </summary>
	/// <param name="character">Character.</param>
	public static void DoDelete(ICharacter character)
	{
		if (character != null)
		{
			Player p = character.GetOwningPlayer();
			CharacterManager.Get().UnregisterCharacter(p.PlayerIndex);
			PlayerEndedSector(p);
		}
	}

	/// <summary>
	/// Makes the palyers take the control of thier characters.
	/// </summary>
	static void UseCharacter(Player player, ICharacter character)
	{
		player.GetController().UseCharacter(character);
	}
	
	/// <summary>
	/// Set the next sector to be spawned in - automatically removes all spawned chars.
	/// </summary>
	static void PlayerNextSector(SectorData next, Player player)
	{
		currentSectors[player.PlayerIndex] = next;
	}

	/// <summary>
	/// Called if a player ends a sector.
	/// </summary>
	/// <param name="p">The player</param>
	static void PlayerEndedSector(Player p)
	{
		{
			// increase the sector number
			sectorNumber[p.PlayerIndex]++;

			// check if a player finished the complete level
			// if we reach the last despawn
			if (sectorNumber[p.PlayerIndex] == currentLevel.Sectors.Count)
			{
				PlayerEndedLevel(p);
				return;
			}
		}
		// enter the next sector for player
		PlayerNextSector(currentLevel.Sectors[sectorNumber[p.PlayerIndex]], p);
		// generate new random char
		ICharacter c = Create(p);
		// bind to controller
		UseCharacter(p, c);
	}
	
	/// <summary>
	/// Called if a player ends a level.
	/// </summary>
	/// <param name="p">The player</param>
	static void PlayerEndedLevel(Player p)
	{
		playersEnded[p.PlayerIndex] = true;
		
		Debug.Log("Level ended by player " + p.PlayerIndex);
		
		p.OnFinish();

		{
			ended = true;
			foreach (bool end in playersEnded)
			{
				if (!end)
				{
					ended = false;
				}
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
	/// Event that is called for a dying character.
	/// </summary>
	/// <param name="character">Character.</param>
	static void OnCharacterDecay(ICharacter character)
	{
		Respawn(character.GetOwningPlayer());
	}

	/// <summary>
	/// Respawns a player in the current sector at the spawn or fighting module.
	/// </summary>
	/// <param name="sector">Sector.</param>
	static void Respawn(Player player)
	{
		if (currentSectors[player.PlayerIndex].ReachedFighting[player.PlayerIndex])
		{
			player.GetCharacter().Spawn(
				currentSectors[player.PlayerIndex].FightingModule.Spawns[(int)player.GetCharacter().CharacterType]);
		}
		else
		{
			player.GetCharacter().Spawn(
				currentSectors[player.PlayerIndex].SpawnModule.Spawns[(int)player.GetCharacter().CharacterType]);
		}
		//Create(reachedFighting[player.PlayerIndex], player);
	}
    
	////////////////////////////////////////////////////////////////////

	static public float GetLevelProgress(ICharacter character)
	{
		if (character != null && CurrentLevel != null)
		{
			float start = currentLevel.Sectors [0].SpawnModule.Spawns[(int)character.CharacterType].transform.position.x;
			float end = currentLevel.Sectors [currentLevel.Sectors.Count - 1].FightingModule.Despawn.transform.position.x;

			float length = Mathf.Abs(start - end);
	
			if (length != 0)
			{
				float progress = Mathf.Abs(start - character.transform.position.x);
				return (progress / length);
			}

		}
		return -1;
	}

	static public float GetSectorProgress(ICharacter character)
	{
		if (character != null && CurrentLevel != null)
		{			
			int pIdx = character.GetOwningPlayer().PlayerIndex;
			float length = Mathf.Abs(
				currentSectors[pIdx].SpawnModule.Spawns[(int)character.CharacterType].transform.position.x - 
				currentSectors[pIdx].FightingModule.Despawn.transform.position.x);

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

	public static SettingsManager.LevelSettings LevelSettings
	{
		get 
		{
			return SettingsManager.Get().CurrentLevelSetings;
		}
	}

	////////////////////////////////////////////////////////////////////

	// progress logic

	static bool[] playersEnded;
	static int[] sectorNumber;
	static SectorData[] currentSectors;

	static bool started;
	static bool ended;

	////////////////////////////////////////////////////////////////////

	// current loaded level, sector and chars

	static LevelData currentLevel;


}

