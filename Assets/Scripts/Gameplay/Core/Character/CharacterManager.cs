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
	/// Registers a character on spawn.
	/// </summary>
	/// <param name="character">Character.</param>
	public void RegisterCharacter(int playerIndex, ICharacter character)
	{
		if (character == null)
		{
			throw new System.ArgumentNullException("character");
		}
		if (characters.ContainsKey(playerIndex) || characters.ContainsValue(character))
		{
			return;
		}
		characters.Add(playerIndex, character);
		
	}

	/// <summary>
	/// Unregisters the character.
	/// </summary>
	/// <param name="character">Character.</param>
	public void UnregisterCharacter(int playerIndex)
	{
		if (characters.ContainsKey(playerIndex))
		{
			characters.Remove(playerIndex);
		}
	}

	////////////////////////////////////////////////////////////////////

	public AirCharacter[] 		AirCharacterTypes;
	public GroundCharacter[] 	GroundCharacterTypes;
	public WaterCharacter[] 	WaterCharacterTypes;

	////////////////////////////////////////////////////////////////////

	Dictionary<int, ICharacter> characters = new Dictionary<int, ICharacter>();

}
