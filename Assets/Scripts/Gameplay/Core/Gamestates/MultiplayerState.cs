using UnityEngine;

/// <summary>
/// Ther multiplayer state
/// </summary>
public class MultiplayerState : IGameState
{
	public MultiplayerState()
	{

	}

	#region IGameState implementation

	public override string GetName()
	{
		return "Multiplayer State";
	}

	public override GamestateType GetGamestateType()
	{
		return GamestateType.Multiplayer;
	}

	public override void Enter()
	{
		//LevelManager.Get().Load();
		//LevelManager.Get().Spawn();
		
		Application.LoadLevel("Multiplayer");
	}

	public override void Leave()
	{
		GUIManager.Get().ClearGUI();
	}

	public override void Reset()
	{

	}

	#endregion
}

