using UnityEngine;
using System.Collections;

public abstract class AbstractAction : IElement
{

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void OnTriggered()
	{
		DoAction();
	}

	protected abstract void DoAction();
}
