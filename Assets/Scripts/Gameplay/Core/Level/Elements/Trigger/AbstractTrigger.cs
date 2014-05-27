using UnityEngine;
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

	protected abstract void TriggerAction(UnityEngine.Component other);

	public AbstractAction[] Actions;

	public bool Active = true;

	public bool TriggerOnce = false;
}
