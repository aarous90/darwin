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

	protected void InvokeTrigger(Component other)
	{
		if (other == null)
			throw new System.ArgumentNullException("other");
		if (TriggerOnce && triggered) return;
		// do the real triggering
		DoTrigger(other);
		// in release mode, delete trigger if only once
		if (!Debug.isDebugBuild && TriggerOnce)
		{
			Object.Destroy(this);
		}
		triggered = true;
	}

	protected abstract void DoTrigger(Component other);

	public AbstractAction[] Actions;
	public bool Active = true;
	public bool TriggerOnce = false;

	private bool triggered = false;
}
