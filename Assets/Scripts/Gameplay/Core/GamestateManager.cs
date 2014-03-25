//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34011
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using Gameplay.Core.Gamestates;
using Gameplay.Core.Type;

namespace Gameplay.Core
{
	public class GamestateManager
	{
		private GamestateManager()
		{
			Initialize();
		}

		private static GamestateManager m_Instance = null;

		////////////////////////////////////////////////////////////////////

		public static GamestateManager Get()
		{
			if (m_Instance != null)
			{
				return m_Instance;
			}
			return m_Instance = new GamestateManager();
		}

		////////////////////////////////////////////////////////////////////
		/// Methods
		////////////////////////////////////////////////////////////////////

		public MainMenuState GetMainMenuState()
		{
			return m_MainMenuState;
		}

		public MultiplayerState GetMultiplayerState()
		{
			return m_MultiplayerState;
		}

		public TrainingState GetTrainingState()
		{
			return m_TrainingState;
		}

		public IGameState GetCurrentState()
		{
			return m_CurrentGameState;
		}

		////////////////////////////////////////////////////////////////////

		public void ChangeState(GamestateType nextState)
		{
			m_CurrentGameState.Leave();

			switch (nextState) // change to next state
			{
			case GamestateType.MainMenu:
				m_CurrentGameState = GetMainMenuState();
				break;
			case GamestateType.Multiplayer:
				m_CurrentGameState = GetMultiplayerState();
				break;
			case GamestateType.Training:
				m_CurrentGameState = GetTrainingState();
				break;
			default:
				throw new Exception("Invalid Gamestate Type!");
			}

			m_CurrentGameState.Enter();
		}

		////////////////////////////////////////////////////////////////////

		private void Initialize()
		{
			if (m_MainMenuState == null)
			{
				return;
			}
			m_MainMenuState = new MainMenuState();

			if (m_MultiplayerState == null)
			{
				return;
			}
			m_MultiplayerState = new MultiplayerState();

			if (m_TrainingState == null)
			{
				return;
			}
			m_TrainingState = new TrainingState();
		}

		////////////////////////////////////////////////////////////////////
		/// Fields
		////////////////////////////////////////////////////////////////////
		 
		private MainMenuState m_MainMenuState;

		private MultiplayerState m_MultiplayerState;

		private TrainingState m_TrainingState;
		
		////////////////////////////////////////////////////////////////////
		
		private IGameState m_CurrentGameState;

		
	}
}

