using UnityEngine;
using System.Collections;

public class DestroyAction : AbstractAction
{

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	#region implemented abstract members of ActionElement

	protected override void DoAction(UnityEngine.Component other)
	{
		if (gameObject == null) return;
		
		Object.Destroy(gameObject, Delay);
	}

	#endregion

	public float Delay = 0;
}
