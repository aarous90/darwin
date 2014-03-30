using UnityEngine;

public class MultiplayerButton : Button 
{
	public override void OnSelect()
	{
		Application.LoadLevel("Multiplayer");
	}
}
