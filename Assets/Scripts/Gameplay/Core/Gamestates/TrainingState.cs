
/// <summary>
/// The training state
/// </summary>
public class TrainingState : IGameState
{
	public TrainingState()
	{

	}

	#region IGameState implementation

	public string GetName()
	{
		return "Training State";
	}

	public GamestateType GetGamestateType()
	{
		return GamestateType.Training;
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

