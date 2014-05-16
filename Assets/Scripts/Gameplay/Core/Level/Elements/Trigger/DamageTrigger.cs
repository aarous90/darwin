using UnityEngine;
using System.Collections;

public class DamageTrigger : AbstractTrigger
{

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	#region implemented abstract members of TriggerElement

	protected override void TriggerAction(Collider other)
	{
		throw new System.NotImplementedException();
	}

	#endregion
}
