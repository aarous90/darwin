using Assets.Scripts.Gameplay.Core.Type;


namespace Assets.Scripts.Gameplay.Core.Gamestates 
{
    /// <summary>
    /// The abstract gamestate
    /// </summary>
	public interface IGameState 
	{

		string GetName();

		GamestateType GetGamestateType();

		void Enter();

		void Leave();

		void Reset();

	}

}
