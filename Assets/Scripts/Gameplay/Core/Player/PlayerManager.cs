using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

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
		return (uint) players.Count;
	}

	private void CreatePlayers()
	{
		int controllerCount = ControllerManager.Get().GetControllers().Count;
		players.Add(0, new Player(0));
		players.Add(1, new Player(1));
	}

	private Dictionary<int, Player> players = new Dictionary<int, Player>();

}
