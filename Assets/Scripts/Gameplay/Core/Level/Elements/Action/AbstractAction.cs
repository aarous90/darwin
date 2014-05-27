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

	public void OnAction(UnityEngine.Component other)
	{
		DoAction(other);
	}

	protected abstract void DoAction(UnityEngine.Component other);
	
	public bool Active = true;
}
