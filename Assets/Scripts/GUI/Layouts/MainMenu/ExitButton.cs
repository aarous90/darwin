using UnityEngine;

public class ExitButton : Button {

	public override void OnSelect()
	{
		Application.Quit();
	}
}
