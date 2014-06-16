using UnityEngine;
using System.Collections;

public abstract class VolumeTrigger : AbstractTrigger
{
	// Use this for initialization
	void Start()
	{
		if (collider == null || rigidbody == null)
		{
			Debug.LogError("The trigger has no collider or rigidbody attached!");
		}
	}

	protected abstract void OnTriggerEnter(Collider other);
	
	protected abstract void OnTriggerExit(Collider other);
	
	protected abstract void OnTriggerStay(Collider other);
}
