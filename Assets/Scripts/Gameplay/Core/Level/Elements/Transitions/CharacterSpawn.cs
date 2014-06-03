using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The Character spawn is responsible to spawn a character in a level.
/// </summary>
public class CharacterSpawn : IElement
{

	void Start()
	{
		TextMesh text = GetComponent<TextMesh>();
		if (text)
		{
			text.renderer.enabled = false;
		}
	}

	void Update()
	{

	}

	/// <summary>
	/// The type of the terrain that spawner is for, 0 - Air, 1 - Ground, 2 - Water.
	/// </summary>
	public int TerrainType = -1;

	/// <summary>
	/// The movement offset the character can move up and down and the camera will follow.
	/// </summary>
	public float MovementOffset = 3;
}

