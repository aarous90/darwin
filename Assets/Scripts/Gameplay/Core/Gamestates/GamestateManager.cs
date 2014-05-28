
using System;
using UnityEngine;

/// <summary>
/// The Gamestate manager cares about the states the game has.
/// </summary>
public class GamestateManager : MonoBehaviour
{
	public static GamestateManager Get()
	{
		GameObject im = GameObject.Find("GamestateManager");
		if (im != null)
		{
			return im.GetComponent<GamestateManager>();
		}
		return null;
	}
	
	// Use this for initialization
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Initialize();
		// enter the first state manually
		currentGameState = GetMainMenuState();
		currentGameState.Enter();
	}

	void Update()
	{

	}
	
	////////////////////////////////////////////////////////////////////
	/// Methods
	////////////////////////////////////////////////////////////////////
	
	public MainMenuState GetMainMenuState()
	{
		return mainMenuState;
	}
	
	public MultiplayerState GetMultiplayerState()
	{
		return multiplayerState;
	}
	
	public TrainingState GetTrainingState()
	{
		return trainingState;
	}
	
	public TrainingSettingsState GetTrainingSettingsState()
	{
		return trainingSettingsState;
	}
	
	public IGameState GetCurrentState()
	{
		return currentGameState;
	}
	
	////////////////////////////////////////////////////////////////////
	
	public void ChangeState(GamestateType nextState)
	{
		if (currentGameState == null)
		{
			return;
		}

		print("Changing From " + currentGameState.GetGamestateType() + " to " + nextState);

		currentGameState.Leave();
		
		switch (nextState) // change to next state
		{
			case GamestateType.MainMenu:
				currentGameState = GetMainMenuState();
				break;
			case GamestateType.Multiplayer:
				currentGameState = GetMultiplayerState();
				break;
			case GamestateType.Training:
				currentGameState = GetTrainingState();
				break;
			case GamestateType.TrainingSettings:
				currentGameState = GetTrainingSettingsState();
				break;
			case GamestateType.Exit:
				currentGameState = null;
				return;
			default:
				throw new Exception("Invalid Gamestate Type!");
		}
		
		currentGameState.Enter();
	}
	
	////////////////////////////////////////////////////////////////////
	
	private void Initialize()
	{
		if (mainMenuState != null)
		{
			return;
		}
		mainMenuState = new MainMenuState();
		
		if (multiplayerState != null)
		{
			return;
		}
		multiplayerState = new MultiplayerState();
		
		if (trainingState != null)
		{
			return;
		}
		trainingState = new TrainingState();

		if (trainingSettingsState != null)
		{
			return;
		}
		trainingSettingsState = new TrainingSettingsState();
	}
	
	////////////////////////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////////////////////////
	
	private MainMenuState mainMenuState;
	private MultiplayerState multiplayerState;
	private TrainingState trainingState;
	private TrainingSettingsState trainingSettingsState;
	
	////////////////////////////////////////////////////////////////////
	
	private IGameState currentGameState;
	
	
}
