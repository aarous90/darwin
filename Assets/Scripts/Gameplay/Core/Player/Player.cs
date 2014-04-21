using UnityEngine;
using System.Collections;

public class Player 
{
	public Player(int key, MovementController value)
	{
		PlayerName = "Player " + key;
		PlayerIndex = key;
		playerStats = new PlayerStats(this);

		controller = value;
	}

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}

	public MovementController GetController()
	{
		if (controller == null)
		{
			throw new UnityException("Player " + PlayerIndex + " has no valid controller!");
		}
		return controller;
	}

	public ICharacter GetCharacter()
	{
		MovementController c = GetController();
		return c.CurrentCharacter;

	}

	////////////////////////////////////////////////////////////////////

	public string 				PlayerName;

	public int 				PlayerIndex;

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// The movement controller of this player.
	/// </summary>
	MovementController 			controller;

	/// <summary>
	/// The player stats.
	/// </summary>
	PlayerStats 				playerStats;
}
