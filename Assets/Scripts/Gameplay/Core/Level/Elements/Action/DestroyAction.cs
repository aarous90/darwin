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

	protected override void DoAction()
	{
		if (deleted) return;

		for (int i = 0; i < DestroyObjects.Length; i++)
		{
			GameObject obj = GameObject.Find(DestroyObjects[i].name);
			if (obj != null)
			{
				Object.Destroy(obj, 1);
			}
		}

		deleted = true;
	}

	#endregion

	/// <summary>
	/// The list of objects that will be destoryed if the action is triggered.
	/// </summary>
	public GameObject[] DestroyObjects;

	/// <summary>
	/// The deleted flag marks if the action was already triggered.
	/// </summary>
	bool deleted = false;
}
