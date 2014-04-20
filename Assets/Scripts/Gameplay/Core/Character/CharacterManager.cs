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

	public void RegisterSpawn(CharacterSpawn spawner)
	{
		if (spawner == null)
		{
			throw new System.ArgumentNullException("spawner");
		}
		if (spawners.Contains(spawner))
		{
			return;
		}
		spawners.Add(spawner);
	}

	////////////////////////////////////////////////////////////////////

	HashSet<CharacterSpawn> spawners = new HashSet<CharacterSpawn>();

}
