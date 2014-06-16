using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The Player manager takes care of the players/controllers registered to a game session.
/// </summary>
public class PlayerManager : MonoBehaviour
{

	public static PlayerManager Get()
	{
		GameObject manager = GameObject.Find("PlayerManager");
		if (manager != null)
		{
			return manager.GetComponent<PlayerManager>();
		}
		return null;
	}
	
	// Use this for initialization
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		CreatePlayers();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	////////////////////////////////////////////////////////////////////

	public uint GetPlayerCount()
	{
		return (uint)activePlayers.Count;
	}

	/// <summary>
	/// Gets a player by its index.
	/// </summary>
	/// <returns>The player with the index or null if not found.</returns>
	/// <param name="index">The index of the player to be returned</param>
	public Player GetPlayer(int index)
	{
		if (index >= 0 && activePlayers.ContainsKey(index))
		{
			return activePlayers [index];
		}
		return null;
	}

	/// <summary>
	/// Creates the players based on the controllers the controller manager offers.
	/// </summary>
	void CreatePlayers()
	{
		ControllerManager cm = ControllerManager.Get();
		if (cm != null)
		{
			cm.ControllerConnectedEvent += new OnControllerConnectedHandler(OnControllerConnected);
			cm.ControllerDisconnectedEvent += new OnControllerDisconnectedHandler(OnControllerDisconnected);
		} else
		{
			Debug.LogError("ControllerManager is not initialized properly!");
		}
	}

	void OnControllerConnected(int id, MovementController controller)
	{
		players.Add(id, new Player(id, controller));
	}
	
	void OnControllerDisconnected(int id, MovementController controller)
	{
		players.Remove(id);
	}

	public void ActivatePlayer(int id)
	{
		Player p;
		if (players.TryGetValue(id, out p) && p != null)
		{
			activePlayers.Add(id, p);
		}
	}

	public void DeactivatePlayer(int id)
	{
		Player p;
		if (activePlayers.TryGetValue(id, out p))
		{
			activePlayers.Remove(id);
		}
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// All players that are managed.
	/// </summary>
	Dictionary<int, Player> players = new Dictionary<int, Player>();
	
	Dictionary<int, Player> activePlayers = new Dictionary<int, Player>();
}
