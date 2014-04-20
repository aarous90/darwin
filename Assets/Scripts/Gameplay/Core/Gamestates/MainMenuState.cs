
/// <summary>
/// The main menu state
/// </summary>
public class MainMenuState : IGameState
{
	public MainMenuState()
	{

	}

	#region IGameState implementation

	public string GetName()
	{
		return "Main Menu State";
	}

	public GamestateType GetGamestateType()
	{
		return GamestateType.MainMenu;
	}

	public void Enter()
	{

	}

	public void Leave()
	{

	}

	public void Reset()
	{

	}

	#endregion
}
