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
				int hitIndex = 0;
				float smallestHitDistance = Mathf.Infinity;
				float offset = Collider.bounds.extents.x - (Collider.bounds.extents.x * 0.1f);

				float direction = (deltaY > 0) ? 1 : -1;
				
				float rayLength = Collider.bounds.extents.y + Skin + (Grounded ? (2 * Collider.bounds.extents.y) : Mathf.Abs (deltaY));
			
				for (int i = 0; i <= SideDivisions; i++) {

						Vector2 raycastOrigin = new Vector2 (Collider.bounds.center.x + offset - (offset * 2 / SideDivisions * i), Collider.bounds.center.y);
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

						transform.Translate ((Vector2.up * direction) * (Hits [hitIndex].distance - (Collider.bounds.extents.y + Skin)), Space.World);
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
				SideCollision = false;

				if (deltaX != 0) {

						float direction = Mathf.Sign (deltaX);
						float lastHit = 0;
						float offset = Collider.bounds.extents.y - (Collider.bounds.extents.y * 0.1f);

						for (int i = 0; i <= SideDivisions; i++) {
				
								Vector2 raycastOrigin = new Vector2 (Collider.bounds.center.x, Collider.bounds.center.y + offset - (offset * 2 / SideDivisions * i));
								Debug.DrawRay (raycastOrigin, new Vector2 (direction, 0));

								if (Physics.Raycast (raycastOrigin, Vector2.right * direction, out Hits [i], Collider.bounds.extents.x + Skin + Mathf.Abs (deltaX))) {
			
										if (lastHit > 0) {

												float angle = Vector2.Angle (Hits [i].point - Hits [i - 1].point, Vector2.right);

												if (Mathf.Abs (angle - 90) < DriftAngle) {

														transform.Translate ((Vector2.right * direction) * (Hits [i].distance - (Collider.bounds.extents.x + Skin)), Space.World);
														deltaX = 0;
														SideCollision = true;
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
		[HideInInspector]
		public bool								SideCollision;

		public float							DriftAngle = 5;

////////////////////////////////////////////////////////////////////

		private Collider 						Collider;
		private Vector2 						MoveTransform;
		private float							Skin = 0.05f;
		private int 							SideDivisions = 4;
		private RaycastHit 						Hit;
		private RaycastHit[]					Hits;
}
