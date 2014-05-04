﻿using UnityEngine;
using System.Collections;

public class BoxTrigger : TriggerElement
{

	// Use this for initialization
	void Start()
	{
		triggerBox = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	#region implemented abstract members of TriggerElement

	protected override void TriggerAction()
	{
		Action.DoAction();
	}

	#endregion

	void OnTriggerEnter(Collider other)
	{
		// trigger only for characters
		if (other.gameObject.GetComponent<ICharacter>() != null)
		{
			TriggerAction();
		}
	}

	void OnTriggerExit(Collider other)
	{
		
	}

	void OnTriggerStay(Collider other)
	{

	}

	BoxCollider triggerBox;
}
