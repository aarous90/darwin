
using UnityEngine;

public class TrainingButton : Button 
{
	public override void OnSelect()
	{
		GamestateManager.Get().ChangeState(GamestateType.Training);
		Application.LoadLevel("Training");
	}
}
