using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The Character spawn is responsible to spawn a character in a level.
/// </summary>
public class CharacterSpawn : MonoBehaviour
{
	public CharacterSpawn()
	{

	}

	void Start()
	{
		CharacterManager.Get().RegisterSpawn(this);
	}

	void Update()
	{

	}

	public void DoSpawn(ICharacter character)
	{
		character.Spawn(this);
	}

	/// <summary>
	/// Gets or sets the test sector this spawn leads in.
	/// </summary>
	/// <value>The test sector.</value>
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
	public bool StartSpawn /* = false */;

	/// <summary>
	/// The test sector this spawn leads in.
	/// </summary>
	uint testSector /* = 0 */;


}

