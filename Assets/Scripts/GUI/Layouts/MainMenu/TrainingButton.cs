
using UnityEngine;

public class TrainingButton : Button 
{
	public override void OnSelect()
	{
		Application.LoadLevel("Training");
	}
}
