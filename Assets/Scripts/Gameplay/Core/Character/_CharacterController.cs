﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class _CharacterController : MonoBehaviour
{
		int SideDivisions = 2;
		private float skin = .005f;
		RaycastHit hit;
		bool movementStopped;
		bool grounded;
		Collider collider;
		// Use this for initialization
		void Start ()
		{
				collider = GetComponent<BoxCollider> ();
		}
	
		// Update is called once per frame
		void Update ()
		{

		}
	
		public void move (Vector2 moveDirection)
		{
				float deltaY = moveDirection.y;
				float deltaX = moveDirection.x;
		
				//vertical collision
				grounded = false;
				for (int i = 0; i <= SideDivisions; i++) {
			
						float direction = Mathf.Sign (deltaY);
						float RayOriginY = collider.bounds.center.y + collider.bounds.extents.y * direction;
						float RayOriginX = collider.bounds.center.x + collider.bounds.extents.x - collider.bounds.extents.x * 2 / SideDivisions * i;
			
						Debug.DrawRay (new Vector2 (RayOriginX, RayOriginY), new Vector2 (0, direction));
			
						if (Physics.Raycast (new Vector2 (RayOriginX, RayOriginY), Vector2.up * direction, out hit, Mathf.Abs (deltaY) + skin)) {
								float distance = hit.distance;
								if (distance > skin) {
										deltaY = distance * direction - skin * direction;
								} else {
										deltaY = 0;
										grounded = true;
										break;
					
								}
						}
				}
		
				//horizontal collision
				movementStopped = false;
				for (int i = 0; i <= SideDivisions; i++) {
			
						float direction = Mathf.Sign (deltaX);
						float RayOriginY = collider.bounds.center.y + collider.bounds.extents.y - collider.bounds.extents.y * 2 / SideDivisions * i;
						float RayOriginX = collider.bounds.center.x + collider.bounds.extents.x * direction;
			
						Debug.DrawRay (new Vector2 (RayOriginX, RayOriginY), new Vector2 (direction, 0));
			
						if (Physics.Raycast (new Vector2 (RayOriginX, RayOriginY), Vector2.right * direction, out hit, Mathf.Abs (deltaX) + skin)) {
								float distance = hit.distance;
								if (distance > skin) {
										deltaX = distance * direction - skin * direction;
								} else {
										deltaX = 0;
								}
				
								movementStopped = true;
								break;
				
						}
				}
		
				//diagonal collision
				if (!grounded && !movementStopped) {
			
						Vector3 playerDir = new Vector3 (deltaX, deltaY);
						Vector3 o = new Vector3 (collider.bounds.center.x + collider.bounds.extents.x * Mathf.Sign (deltaX), collider.bounds.center.y + collider.bounds.extents.y * Mathf.Sign (deltaY));
			
						Debug.DrawRay (o, playerDir.normalized);
			
						if (Physics.Raycast (o, playerDir.normalized, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY))) {
								grounded = true;
								deltaY = 0;
						}
				}
		
		
				transform.Translate (new Vector2 (deltaX, deltaY), Space.World);
		}
}
