using UnityEngine;

public class MultiplayerButton : Button 
{
	public override void OnSelect()
	{
		GamestateManager.Get().ChangeState(GamestateType.Multiplayer);
	}
}
