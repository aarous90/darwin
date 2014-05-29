using UnityEngine;
using System.Collections;

public class BackButton : Button
{
	public override void OnSelect()
	{
		GamestateManager.Get().ChangeState(GamestateType.MainMenu);
	}
}
