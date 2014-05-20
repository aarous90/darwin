using UnityEngine;
using System.Collections;

public delegate void OnPlayerFinishesHandler(Player player);

public delegate void OnPlayerWinsHandler(Player player);

public delegate void OnPlayerLoosesHandler(Player player);

/// <summary>
/// The Player class holds the movement controller 
/// which controls the different character types,
/// also handles the events for loosing, winning, and finishing.
/// </summary>
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

	/// <summary>
	/// Gets the movement-controller this player has, the controller contros the character.
	/// </summary>
	/// <returns>The controller.</returns>
	public MovementController GetController()
	{
		if (controller == null)
		{
			throw new UnityException("Player " + PlayerIndex + " has no valid controller!");
		}
		return controller;
	}

	/// <summary>
	/// Gets the character from the used movement-controller.
	/// </summary>
	/// <returns>The character.</returns>
	public ICharacter GetCharacter()
	{
		MovementController c = GetController();
		return c.CurrentCharacter;

	}

	/// <summary>
	/// Raises the finish event.
	/// </summary>
	public void OnFinish()
	{
		PlayerFinishesEvent(this);
	}

	/// <summary>
	/// Raises the loose event.
	/// </summary>
	public void OnLoose()
	{
		PlayerLoosesEvent(this);
	}

	/// <summary>
	/// Raises the win event.
	/// </summary>
	public void OnWin()
	{
		PlayerWinsEvent(this);
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Occurs when player looses.
	/// </summary>
	public event OnPlayerLoosesHandler 		PlayerLoosesEvent;

	/// <summary>
	/// Occurs when player finishes.
	/// </summary>
	public event OnPlayerFinishesHandler 	PlayerFinishesEvent;

	/// <summary>
	/// Occurs when player wins.
	/// </summary>
	public event OnPlayerWinsHandler 		PlayerWinsEvent;

	////////////////////////////////////////////////////////////////////

	public string 							PlayerName;

	public int 								PlayerIndex;

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// The movement controller of this player.
	/// </summary>
	MovementController 						controller;

	/// <summary>
	/// The player stats.
	/// </summary>
	PlayerStats 							playerStats;
}
