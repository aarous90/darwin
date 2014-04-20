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

	////////////////////////////////////////////////////////////////////

	Dictionary<int, CharacterSpawn> spawners = new Dictionary<int, CharacterSpawn>();

}
