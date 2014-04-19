using UnityEngine;
using System.Collections;

public class Player 
{

	public Player(uint index)
	{
		PlayerName = "Player " + index;
		PlayerIndex = index;
		playerStats = new PlayerStats(this);
	}

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}

	public string 			PlayerName;

	public uint 			PlayerIndex;

	////////////////////////////////////////////////////////////////////

	private PlayerStats 	playerStats;
}
