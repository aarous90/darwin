using UnityEngine;
using System.Collections;

public class FallingAction : AbstractAction
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
		//GameObject go = GameObject.Find(name);
		gameObject.rigidbody.useGravity = true;
		if (FadeTime > 0)
		{
			Destroy(gameObject, FadeTime);
		}
	}

	#endregion

	public float FadeTime = 0;
}
 