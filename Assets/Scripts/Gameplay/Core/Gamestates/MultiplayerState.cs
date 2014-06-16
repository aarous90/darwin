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
		ControllerManager.Get().MaximumUsable = 2;
		PlayerManager.Get().ActivatePlayer(0);
		PlayerManager.Get().ActivatePlayer(1);
		Application.LoadLevel("Multiplayer");
	}

	public override void Leave()
	{
		GUIManager.Get().ClearGUI();
		CameraManager.Get().Clear();
		PlayerManager.Get().DeactivatePlayer(0);
		PlayerManager.Get().DeactivatePlayer(1);
	}

	public override void Reset()
	{

	}

	#endregion
}

