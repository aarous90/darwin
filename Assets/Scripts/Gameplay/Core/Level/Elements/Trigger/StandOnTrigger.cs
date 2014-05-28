using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandOnTrigger : VolumeTrigger
{
// Update is called once per frame
	void Update()
	{
		transform.Translate(0, 0, 0);
	}

	#region implemented abstract members of TriggerElement

	protected override void DoTrigger(UnityEngine.Component other)
	{
		foreach (AbstractAction a in Actions)
		{
			if (a != null)
				a.OnAction(other);
		}
	}

	#endregion

	#region implemented abstract members of VolumeTrigger

	protected override void OnTriggerEnter(Collider other)
	{
		if (!Active)
			return;
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			InvokeTrigger(other);
			
			oldParents.Add(other.gameObject, other.gameObject.transform.parent);

			other.gameObject.transform.parent = this.transform;

			//triggered = true;
		}
	}

	protected override void OnTriggerExit(Collider other)
	{
		if (!Active)
			return;
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			InvokeTrigger(other);
			Transform oldParent;
			if (oldParents.TryGetValue(other.gameObject, out oldParent))
			{
				other.gameObject.transform.parent = oldParent;
				oldParents.Remove(other.gameObject);
			}
			//triggered = false;
		}
	}

	protected override void OnTriggerStay(Collider other)
	{
//		if (!triggered)
//		{
//			// trigger only for characters
//			if (other.gameObject.GetComponent<ICharacter>() != null)
//			{
//				// trigger only if the trigger collider contains the complete character collider
//				if (collider.bounds.Contains(new Vector3(other.collider.bounds.center.x - other.collider.bounds.extents.x, collider.bounds.center.y, collider.bounds.center.z)) 
//					&& collider.bounds.Contains(new Vector3(other.collider.bounds.center.x + other.collider.bounds.extents.x, collider.bounds.center.y, collider.bounds.center.z)))
//				{
//					TriggerAction(other);
//					old = other.transform.parent;
//					other.transform.parent = this.transform;
//					triggered = true;
//				}
//			}
//		}
	}

	#endregion
	
	Dictionary<GameObject, Transform> oldParents = new Dictionary<GameObject, Transform>();

	//bool triggered = false;
}
