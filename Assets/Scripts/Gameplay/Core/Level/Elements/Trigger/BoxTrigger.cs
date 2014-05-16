using UnityEngine;
using System.Collections;

public class BoxTrigger : VolumeTrigger
{	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(0,0,0);
	}

	#region implemented abstract members of TriggerElement

	protected override void TriggerAction(Collider other)
	{
		Action.OnTriggered(other);
	}

	#endregion

	protected override void OnTriggerEnter(Collider other)
	{
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			TriggerAction(other);
		}
	}

	protected override void OnTriggerExit(Collider other)
	{
		
	}

	protected override void OnTriggerStay(Collider other)
	{

	}
}
