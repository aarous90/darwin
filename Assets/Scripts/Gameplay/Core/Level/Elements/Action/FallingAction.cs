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

	protected override void DoAction(Collider other)
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

		foreach (GameObject obj in objects)
		{
			if (obj != null && obj.GetComponent<FallingAction>() == null)
			{
				obj.rigidbody.useGravity = true;
			}
		}
	}

	#endregion

	public float FadeTime = 5f;
}
 