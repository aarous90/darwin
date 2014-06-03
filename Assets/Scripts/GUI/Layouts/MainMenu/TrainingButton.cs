
using UnityEngine;

public class TrainingButton : Button 
{
	protected override void Init()
	{
		base.Init();
		GUIManager.Get().FocusIndex(0);

	}

	void Update()
	{
//		if ()
//		{
//
//		}
//		transform.position.x = 
	}

	public override void OnSelect()
	{
		if (ControllerManager.Get().AvailabeJoystickCount >= 1)
		{
			GamestateManager.Get().ChangeState(GamestateType.TrainingSettings);
		}
	}

	private float oldX;
}
