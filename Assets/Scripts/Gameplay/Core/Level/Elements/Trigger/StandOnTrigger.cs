using UnityEngine;
using System.Collections;

public class StandOnTrigger : VolumeTrigger
{
// Update is called once per frame
	void Update()
	{
		transform.Translate(0, 0, 0);
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
			triggered = false;
		}
	}

	protected override void OnTriggerStay(Collider other)
	{
		if (!triggered)
		{
			// trigger only for characters
			if (other.gameObject.GetComponent<ICharacter>() != null)
			{
				// trigger only if the trigger collider contains the complete character collider
				if (collider.bounds.Contains(new Vector3(other.collider.bounds.center.x - other.collider.bounds.extents.x, collider.bounds.center.y, collider.bounds.center.z)) 
					&& collider.bounds.Contains(new Vector3(other.collider.bounds.center.x + other.collider.bounds.extents.x, collider.bounds.center.y, collider.bounds.center.z)))
				{
					TriggerAction(other);
					old = other.transform.parent;
					other.transform.parent = this.transform;
					triggered = true;
				}
			}
		}
	}

#endregion


	Transform old;
	bool triggered = false;
}
