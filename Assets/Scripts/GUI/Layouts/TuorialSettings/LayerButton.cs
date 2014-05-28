using UnityEngine;
using System.Collections;

public class LayerButton : Button {

	protected override void Init()
	{
		base.Init();

		if (IsFirst) GUIManager.Get().FocusIndex(0);
    }
    
	public override void OnSelect()
	{
		SettingsManager.LevelSettings levelSettings = SettingsManager.Get().CurrentLevelSetings;

		levelSettings.PreferedLayer[0] = LevelLayer;
		levelSettings.PreferedLayer[1] = LevelLayer;

		SettingsManager.Get().ApplyLevelSettings(levelSettings);

		GamestateManager.Get().ChangeState(GamestateType.Training);
	}

	/// <summary>
	/// The level layer.
	/// </summary>
	public int LevelLayer = 0;

	public bool IsFirst;
}
