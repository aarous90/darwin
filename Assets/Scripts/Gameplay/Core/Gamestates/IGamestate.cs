using Gameplay.Core.Type;

namespace Gameplay.Core.Gamestates 
{

	public interface IGameState 
	{

		string GetName();

		GamestateType GetGamestateType();

		void Enter();

		void Leave();

		void Reset();

	}

}
