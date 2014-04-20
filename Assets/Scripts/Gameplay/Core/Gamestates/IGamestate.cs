﻿
/// <summary>
/// The gamestate interface
/// </summary>
public interface IGameState 
{
	string GetName();

	GamestateType GetGamestateType();

	void Enter();

	void Leave();

	void Reset();

}

