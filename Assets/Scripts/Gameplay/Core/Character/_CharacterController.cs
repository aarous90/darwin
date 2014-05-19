using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class _CharacterController : MonoBehaviour
{		
// Use this for initialization
		void Awake ()
		{
				Collider = GetComponent<BoxCollider> ();
				Hits = new RaycastHit [SideDivisions + 1];
		}
// Use this for initialization
		void Start ()
		{

		}
// Update is called once per frame
		void Update ()
		{

		}

		public void Move (Vector2 moveDirection)
		{
				float deltaY = moveDirection.y;
				float deltaX = moveDirection.x;

				deltaX = HorizontalCollisions (deltaX);
				deltaY = VerticalCollisions (deltaY);
				
				MoveTransform = new Vector2 (deltaX, deltaY);
				transform.Translate (MoveTransform, Space.World);
		}

//Check for vertical collisions in movementdirection
		private float VerticalCollisions (float deltaY)
		{
				bool rayHasHit = false;
				float direction = (deltaY > 0) ? 1 : -1;
				float smallestHitDistance = Mathf.Infinity;
				float rayLength = Collider.bounds.extents.y + (Grounded ? 2 : Mathf.Abs (deltaY * Time.deltaTime));
				int hitIndex = 0;

				for (int i = 0; i <= SideDivisions; i++) {

						Vector2 raycastOrigin = new Vector2 (Collider.bounds.center.x + Collider.bounds.extents.x - (Collider.bounds.extents.x * 2 / SideDivisions * i), Collider.bounds.center.y);
						Debug.DrawRay (raycastOrigin, new Vector2 (0, direction));

						if (Physics.Raycast (raycastOrigin, Vector2.up * direction, out Hits [i], rayLength)) {

								rayHasHit = true;

								if (Hits [i].distance < smallestHitDistance) {

										hitIndex = i;
										smallestHitDistance = Hits [i].distance;
								}

						}
				}

				if (rayHasHit) {

						transform.Translate ((Vector2.up * direction) * (Hits [hitIndex].distance - (Collider.bounds.extents.y)), Space.World);
						deltaY = 0;
						Grounded = true;

				} else {

						Grounded = false;

				}

				return deltaY;
		}

//Check for horizontal collisions in movementdirection
		private float HorizontalCollisions (float deltaX)
		{

				if (deltaX != 0) {
						float direction = Mathf.Sign (deltaX);
						float lastHit = 0;

						for (int i = 0; i <= SideDivisions; i++) {
				
								Vector2 raycastOrigin = new Vector2 (Collider.bounds.center.x, Collider.bounds.center.y + Collider.bounds.extents.y - (Collider.bounds.extents.y * 2 / SideDivisions * i));
								Debug.DrawRay (raycastOrigin, new Vector2 (direction, 0));

								if (Physics.Raycast (raycastOrigin, Vector2.right * direction, out Hits [i], Collider.bounds.extents.x + Mathf.Abs (deltaX))) {
			
										if (lastHit > 0) {

												float angle = Vector2.Angle (Hits [i].point - Hits [i - 1].point, Vector2.right);

												if (Mathf.Abs (angle - 90) < DriftAngle) {

														transform.Translate ((Vector2.right * direction) * (Hits [i].distance - (Collider.bounds.extents.x)), Space.World);
														deltaX = 0;
														break;

												}

										}

										lastHit = Hits [i].distance;

								}
						}
				}

				return deltaX;
		}


////////////////////////////////////////////////////////////////////

		[HideInInspector]
		public bool								Grounded;

		public float							DriftAngle = 5;

////////////////////////////////////////////////////////////////////

		private Collider 						Collider;
		private Vector2 						MoveTransform;
		private int 							SideDivisions = 4;
		private RaycastHit 						Hit;
		private RaycastHit[]					Hits;
}
