using UnityEngine;

public class MultiplayerButton : Button 
{
	public override void OnSelect()
	{
		if (ControllerManager.Get().AvailabeJoystickCount >= 2)
		{
			SettingsManager.LevelSettings levelSettings = SettingsManager.Get().CurrentLevelSetings;
			// use random chars in mp
			levelSettings.PreferedLayer [0] = -1;
			levelSettings.PreferedLayer [1] = -1;
			
			SettingsManager.Get().ApplyLevelSettings(levelSettings);

			GamestateManager.Get().ChangeState(GamestateType.Multiplayer);
		}
	}
}
