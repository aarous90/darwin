using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Character manager.
/// </summary>
public class CharacterManager : MonoBehaviour
{
	public static CharacterManager Get()
	{
		GameObject manager = GameObject.Find("CharacterManager");
		if (manager != null)
		{
			return manager.GetComponent<CharacterManager>();
		}
		return null;
	}

	void Start()
	{
		Object.DontDestroyOnLoad(this);
	}

	void Update()
	{

	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Gets the spawners.
	/// </summary>
	/// <value>The spawners.</value>
	public Dictionary<int, CharacterSpawn> Spawners
	{
		get
		{
			return new Dictionary<int, CharacterSpawn>(spawners);
		}
	}

	/// <summary>
	/// Gets the characters.
	/// </summary>
	/// <value>The characters.</value>
	public Dictionary<int, ICharacter> Characters
	{
		get
		{
			return new Dictionary<int, ICharacter>(characters);
		}
	}

	/// <summary>
	/// Registers a CharacterSpawn automatically on start.
	/// </summary>
	/// <param name="spawner">Spawner.</param>
	public void RegisterSpawn(CharacterSpawn spawner)
	{
		if (spawner == null)
		{
			throw new System.ArgumentNullException("spawner");
		}
		if (spawners.ContainsKey(spawner.PlayerIndex) || spawners.ContainsValue(spawner))
		{
			return;
		}
		spawners.Add(spawner.PlayerIndex, spawner);
	}

	/// <summary>
	/// Unregisters the CharacterSpawn.
	/// </summary>
	/// <param name="characterSpawn">Character spawn.</param>
	public void UnregisterSpawn(CharacterSpawn characterSpawn)
	{
		if (spawners.ContainsKey(characterSpawn.PlayerIndex))
		{
			spawners.Remove(characterSpawn.PlayerIndex);
        }
	}

	/// <summary>
	/// Registers a character on spawn.
	/// </summary>
	/// <param name="character">Character.</param>
	public void RegisterCharacter(ICharacter character)
	{
		if (character == null)
		{
			throw new System.ArgumentNullException("character");
		}
		if (characters.ContainsKey(character.GetOwningPlayer().PlayerIndex) || characters.ContainsValue(character))
		{
			return;
		}
		characters.Add(character.GetOwningPlayer().PlayerIndex, character);
		
	}

	/// <summary>
	/// Unregisters the character.
	/// </summary>
	/// <param name="character">Character.</param>
	public void UnregisterCharacter(ICharacter character)
	{
		if (characters.ContainsKey(character.GetOwningPlayer().PlayerIndex))
		{
			characters.Remove(character.GetOwningPlayer().PlayerIndex);
		}
	}

	////////////////////////////////////////////////////////////////////

	public ICharacter[] CharacterTypes;

	////////////////////////////////////////////////////////////////////

	Dictionary<int, CharacterSpawn> spawners = new Dictionary<int, CharacterSpawn>();
	Dictionary<int, ICharacter> characters = new Dictionary<int, ICharacter>();

}
