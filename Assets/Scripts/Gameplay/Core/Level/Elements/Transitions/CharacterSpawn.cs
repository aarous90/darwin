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

	public ICharacter DoSpawn(Player player, ICharacter character)
	{
		if (PlayerManager.Get().GetPlayer(player.PlayerIndex) != null)
		{
			ICharacter spawned;
			if ((spawned = character.Create(player, this)) != null)
			{
				return spawned;
			}
		}
		return null;
	}

	/// <summary>
	/// The type of the terrain that spawner is for, 0 - Air, 1 - Ground, 2 - Water.
	/// </summary>
	public int TerrainType = -1;
}

