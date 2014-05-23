using UnityEngine;

/// <summary>
/// The main menu state
/// </summary>
public class MainMenuState : IGameState
{
	public MainMenuState()
	{

	}

	#region IGameState implementation

	public override string GetName()
	{
		return "Main Menu State";
	}

	public override GamestateType GetGamestateType()
	{
		return GamestateType.MainMenu;
	}

	public override void Enter()
	{
		ControllerManager.Get().MaximumUsable = 1;
		Application.LoadLevel("MainMenu");
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
