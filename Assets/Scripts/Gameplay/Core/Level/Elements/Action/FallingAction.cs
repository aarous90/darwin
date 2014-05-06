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

	protected override void DoAction()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

		foreach (GameObject obj in objects)
		{
			obj.rigidbody.useGravity = true;
		}
	}

	#endregion

	public float FadeTime = 5f;
}
 