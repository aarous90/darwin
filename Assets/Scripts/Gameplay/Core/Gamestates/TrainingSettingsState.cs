using UnityEngine;

/// <summary>
/// The main menu state
/// </summary>
public class TrainingSettingsState : IGameState
{
	public TrainingSettingsState()
	{
		
	}
	
	#region IGameState implementation
	
	public override string GetName()
	{
		return "Training Settings State";
	}
	
	public override GamestateType GetGamestateType()
	{
		return GamestateType.TrainingSettings;
	}
	
	public override void Enter()
	{
		ControllerManager.Get().MaximumUsable = 1;
		Application.LoadLevel("TrainingSettings");
	}
	
	public override void Leave()
	{
		GUIManager.Get().ClearGUI();
		CameraManager.Get().Clear();
	}
	
	public override void Reset()
	{
		
	}
	
	#endregion
}
