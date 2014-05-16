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
		Application.LoadLevel("Training");
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

