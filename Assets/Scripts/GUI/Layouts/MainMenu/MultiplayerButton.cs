using UnityEngine;

public class MultiplayerButton : Button 
{
	public override void OnSelect()
	{
		if (ControllerManager.Get().AvailabeJoystickCount >= 2)
		{
			GamestateManager.Get().ChangeState(GamestateType.Multiplayer);
		}
	}
}
