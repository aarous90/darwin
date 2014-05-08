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

	protected override void DoAction()
	{
		if (deleted) return;

		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

		if (objects == null) return;

		foreach (GameObject obj in objects)
		{
			if (obj != null && obj.GetComponent<DestroyAction>() == null)
			{
				Object.Destroy(obj, Delay);
			}
		}

		deleted = true;
	}

	#endregion

	public float Delay = 0;

	/// <summary>
	/// The deleted flag marks if the action was already triggered.
	/// </summary>
	bool deleted = false;
}
