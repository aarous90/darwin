using UnityEngine;

/// <summary>
/// The training state
/// </summary>
public class TrainingState : IGameState
{
	public TrainingState()
	{

	}

	#region IGameState implementation

	public override string GetName()
	{
		return "Training State";
	}

	public override GamestateType GetGamestateType()
	{
		return GamestateType.Training;
	}

	public override void Enter()
	{
		ControllerManager.Get().MaximumUsable = 1;
		PlayerManager.Get().ActivatePlayer(0);
		Application.LoadLevel("Training");
	}

	public override void Leave()
	{
		GUIManager.Get().ClearGUI();
		CameraManager.Get().Clear();
		PlayerManager.Get().DeactivatePlayer(0);
	}

	public override void Reset()
	{

	}

	#endregion
}

