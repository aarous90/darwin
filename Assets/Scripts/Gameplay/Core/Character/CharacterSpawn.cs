using System;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
	public CharacterSpawn()
	{

	}

	void Start()
	{

	}

	void Update()
	{

	}

	public void DoSpawn(ICharacter character)
	{
		character.Spawn();
	}

	public uint TestSector
	{
		get { return testSector; }
		set { testSector = value; }
	}

	/// <summary>
	/// The index of the player if this is a start spawn.
	/// </summary>
	public int PlayerIndex = -1;

	/// <summary>
	/// The start spawn flag that indicates the beginning of a level.
	/// </summary>
	public bool StartSpawn = false;

	/// <summary>
	/// The test sector this spawn leads in.
	/// </summary>
	private uint testSector = 0;

}

