using UnityEngine;
using System.Collections.Generic;

public class MovementAction : AbstractAction 
{
	void Start()
	{
		if (Waypoints.Length < 2)
		{
			throw new UnityException("There must be at least two waypoints!");
		}

		currentWaypointIndex = 0;
		lastWaypointIndex = Waypoints.Length - 1;
		currentDuration = Duration;

		gameObject.transform.position = Waypoints[currentWaypointIndex].transform.position;
	}

	void Update()
	{
		if (Active)
		{
			if (Waypoints.Length > 0 
			    && currentWaypointIndex > -1
			    && currentWaypointIndex < Waypoints.Length 
			    && Waypoints[currentWaypointIndex] != null)
			{
//				Vector3 fullPath = Waypoints[currentWaypointIndex].transform.position - Waypoints[lastWaypointIndex].transform.position;
//				Vector3 currentPath = gameObject.transform.position - Waypoints[lastWaypointIndex].transform.position;
//				var minLeft = 0.01f;
				if (currentDuration > Time.deltaTime)
				{
					currentDuration -= Time.deltaTime;
					float t = currentDuration / Duration;
					Vector3 next = (t) * Waypoints[lastWaypointIndex].transform.position + (1-t) * Waypoints[currentWaypointIndex].transform.position;
					gameObject.transform.position = next;
				}
				else
				{
					lastWaypointIndex = currentWaypointIndex;
					currentWaypointIndex++;
					
					currentDuration = Duration;

					if (Loop)
					{
						currentWaypointIndex %= Waypoints.Length;
					}
					else if (currentWaypointIndex >= Waypoints.Length)
					{
						Active = false;
					}
				}
			}
		}
	}

	#region implemented abstract members of AbstractAction

	protected override void DoAction(Component other)
	{

	}

	#endregion

	void OnCollisionEnter(Collision collision) 
	{
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}

		oldParents.Add(collision.gameObject, collision.gameObject.transform);
		
		collision.gameObject.transform.parent = this.transform;
	}

	void OnCollisionExit(Collision collision) 
	{
		Transform transform;
		if (oldParents.TryGetValue(collision.gameObject, out transform))
		{
			collision.gameObject.transform.parent = transform;
		}
	}
	
	public float Duration = 1.0f;

	public bool Loop;

	public GameObject[] Waypoints;

	int currentWaypointIndex = 0;

	float currentDuration = 0.0f;

	Vector3 direction;

	int lastWaypointIndex = 0;


	Dictionary<GameObject, Transform> oldParents = new Dictionary<GameObject, Transform>();

}
