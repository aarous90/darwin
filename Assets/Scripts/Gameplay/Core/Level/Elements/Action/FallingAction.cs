using UnityEngine;
using System.Collections;

public class FallingAction : ActionElement
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

	public override void DoAction()
	{
		foreach (GameObject g in FallingObjects)
		{
			g.rigidbody.isKinematic = true;
		}
	}

	#endregion

	public GameObject[] FallingObjects;
}
 