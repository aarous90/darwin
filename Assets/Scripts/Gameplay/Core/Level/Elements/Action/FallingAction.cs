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
		foreach (GameObject g in FallingObjects)
		{
			if (g == null) continue;

			GameObject obj = GameObject.Find(g.name);
			if (obj != null)
			{
				obj.rigidbody.useGravity = true;
			}
		}
	}

	#endregion

	public GameObject[] FallingObjects;
}
 