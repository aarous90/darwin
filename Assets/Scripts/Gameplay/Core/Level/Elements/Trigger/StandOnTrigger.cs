using UnityEngine;
using System.Collections;

public class StandOnTrigger : VolumeTrigger
{
	// Update is called once per frame
	void Update()
	{
		transform.Translate(0,0,0);
	}

	#region implemented abstract members of TriggerElement

	protected override void TriggerAction(UnityEngine.Component other)
	{
		foreach (AbstractAction a in Actions)
		{
			if (a != null)
				a.OnTriggered(other);
		}
	}

	#endregion

	#region implemented abstract members of VolumeTrigger

	protected override void OnTriggerEnter(Collider other)
	{		
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			TriggerAction(other);
			old = other.transform.parent;
			other.transform.parent = this.transform;
		}
	}

	protected override void OnTriggerExit(Collider other)
	{
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			TriggerAction(other);
			other.transform.parent = old;
		}
	}

	protected override void OnTriggerStay(Collider other)
	{

	}

	#endregion


	Transform old;
}
