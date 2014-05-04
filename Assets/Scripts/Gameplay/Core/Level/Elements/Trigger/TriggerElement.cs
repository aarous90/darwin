using UnityEngine;
using System.Collections;

public abstract class TriggerElement : IElement
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

	public ActionElement Action;
}
