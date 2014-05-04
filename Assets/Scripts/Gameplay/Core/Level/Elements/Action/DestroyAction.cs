using UnityEngine;
using System.Collections;

public class DestroyAction : ActionElement
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
		for (int i = 0; i < DestroyObjects.Length; i++)
		{
			DestroyObject(DestroyObjects[i]);
		}
	}

	#endregion

	public GameObject[] DestroyObjects;
}
