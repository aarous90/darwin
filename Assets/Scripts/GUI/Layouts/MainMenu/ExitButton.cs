using UnityEngine;

public class ExitButton : Button {

	public override void OnSelect()
	{
		GamestateManager.Get().ChangeState(GamestateType.Exit);
		Application.Quit();
	}
}
