﻿using UnityEngine;
using System.Collections;

public abstract class AbstractTrigger : IElement
{

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	protected abstract void TriggerAction();

	public AbstractAction Action;
}