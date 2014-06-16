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
		if (Util.Length(Force) > 0)
		{
			Vector3 force;
			if (UseRandomForce)
			{
				force = new Vector3((float) Util.Randomizer.NextDouble() * Force.x,
				                    (float) Util.Randomizer.NextDouble() * Force.y,
				                    (float) Util.Randomizer.NextDouble() * Force.z);
			}
			else
			{
				force = Force;
			}
//			gameObject.rigidbody.AddForce(
//				force); 
//			gameObject.rigidbody.AddTorque(
//				force); 
			gameObject.rigidbody.AddRelativeForce(
				force); 
			gameObject.rigidbody.AddRelativeTorque(
				force); 
				//gameObject.collider.ClosestPointOnBounds(gameObject.transform.position - (force.normalized * 100.0f)));
		}
		if (FadeTime > 0)
		{
			Destroy(gameObject, FadeTime);
		}
	}

	#endregion

	public float FadeTime = 0;
	public Vector3 Force = new Vector3();
	public bool UseRandomForce;


}
 