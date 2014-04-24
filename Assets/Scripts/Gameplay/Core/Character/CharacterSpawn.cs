using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The Character spawn is responsible to spawn a character in a level.
/// </summary>
public class CharacterSpawn : MonoBehaviour
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

	public void DoSpawn(int playerIndex, ICharacter character)
	{
		if (playerIndex > -1 && playerIndex < PlayerManager.Get().GetPlayerCount())
		{
			ICharacter spawned;
			if ((spawned = character.Spawn(PlayerManager.Get().GetPlayer(playerIndex), this)) != null)
			{
				PlayerManager.Get().GetPlayer(playerIndex).GetController().UseCharacter(spawned);
			}
		}
	}

	/// <summary>
	/// The type of the terrain that spawner is for, 0 - Air, 1 - Ground, 2 - Water.
	/// </summary>
	public int TerrainType = -1;
}

