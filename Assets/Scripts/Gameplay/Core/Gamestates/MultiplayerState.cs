
/// <summary>
/// Ther multiplayer state
/// </summary>
using System;


public class MultiplayerState : IGameState
{
	public MultiplayerState()
	{

	}

	#region IGameState implementation

	public string GetName()
	{
		return "Multiplayer State";
	}

	public GamestateType GetGamestateType()
	{
		return GamestateType.Multiplayer;
	}

	public void Enter()
	{
		//LevelManager.Get().Load();
		//LevelManager.Get().Spawn();

		GUIManager.Get().ClearGUI();
	}

	public void Leave()
	{

	}

	public void Reset()
	{

	}

	#endregion
}

