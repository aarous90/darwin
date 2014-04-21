
/// <summary>
/// Ther multiplayer state
/// </summary>
using System;


public class MultiplayerState : IGameState
{
	public MultiplayerState()
	{

	}

	#region IGameState implementation

	public string GetName()
	{
		return "Multiplayer State";
	}

	public GamestateType GetGamestateType()
	{
		return GamestateType.Multiplayer;
	}

	public void Enter()
	{
		//LevelManager.Get().Load();
		//LevelManager.Get().Spawn();
		foreach (var spawn in CharacterManager.Get().Spawners)
		{
			ICharacter[] charTypes = CharacterManager.Get().CharacterTypes;
			Random rand = new Random(0);
			spawn.Value.DoSpawn(charTypes[rand.Next(charTypes.Length)]);
		}
	}

	public void Leave()
	{

	}

	public void Reset()
	{

	}

	#endregion
}

