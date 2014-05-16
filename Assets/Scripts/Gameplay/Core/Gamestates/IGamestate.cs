using UnityEngine;

/// <summary>
/// The gamestate interface
/// </summary>
public abstract class IGameState
{
	public abstract string GetName();

	public abstract GamestateType GetGamestateType();

	public abstract void Enter();

	public abstract void Leave();

	public abstract void Reset();

}

