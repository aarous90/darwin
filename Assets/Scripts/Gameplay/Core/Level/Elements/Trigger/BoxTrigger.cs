using UnityEngine;
using System.Collections;

public class BoxTrigger : VolumeTrigger
{	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(0,0,0);
	}

	void TriggerForCharacter(Collider other)
	{
		ICharacter character = null;
		// trigger only for characters
		if ((character = other.gameObject.GetComponent<ICharacter>()) != null)
		{
			TriggerAction(character);
		}
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
		if (!TriggerOnEnter) return;

		TriggerForCharacter(other);
	}
	
	protected override void OnTriggerExit(Collider other)
	{
		if (!TriggerOnExit) return;
		
		TriggerForCharacter(other);
	}
	
	protected override void OnTriggerStay(Collider other)
	{
		if (!TriggerOnStay) return;
		
		TriggerForCharacter(other);
	}
	#endregion

	public bool TriggerOnEnter = true;

	public bool TriggerOnExit;

	public bool TriggerOnStay;
}
