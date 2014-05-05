using UnityEngine;
using System.Collections;

public abstract class VolumeTrigger : TriggerElement
{
	// Use this for initialization
	void Start()
	{
		if (collider == null || rigidbody == null)
		{
			throw new UnityException("The trigger has no collider or rigidbody attached!");
		}
	}

	protected abstract void OnTriggerEnter(Collider other);
	
	protected abstract void OnTriggerExit(Collider other);
	
	protected abstract void OnTriggerStay(Collider other);
}
