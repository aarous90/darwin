using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class _CharacterController : MonoBehaviour
{		
// Use this for initialization
	void Awake()
	{
		Collider = GetComponent<BoxCollider>();
	}
// Use this for initialization
	void Start()
	{

	}
// Update is called once per frame
	void Update()
	{

	}

	public void Move(Vector2 moveDirection)
	{
		float deltaY = moveDirection.y;
		float deltaX = moveDirection.x;

		deltaY = VerticalCollisions(deltaY);
		deltaX = HorizontalCollisions(deltaX);

		if (!Grounded && !SideCollision)
		{
			deltaY = DiagonalCollisions(deltaX, deltaY);
		}

		MoveTransform = new Vector2(deltaX, deltaY);
		transform.Translate(MoveTransform, Space.World);
	}

//Check for vertical collisions in movementdirection
	private float VerticalCollisions(float deltaY)
	{
		Grounded = false;

		for (int i = 0; i <= SideDivisions; i++)
		{
			float direction = Mathf.Sign(deltaY);
			float RayOriginY = Collider.bounds.center.y + Collider.bounds.extents.y * direction;
			float RayOriginX = Collider.bounds.center.x + Collider.bounds.extents.x - Collider.bounds.extents.x * 2 / SideDivisions * i;
			Debug.DrawRay(new Vector2(RayOriginX, RayOriginY), new Vector2(0, direction));
			if (Physics.Raycast(new Vector2(RayOriginX, RayOriginY), Vector2.up * direction, out Hit, Mathf.Abs(deltaY) + Skin))
			{
				if (Hit.collider.gameObject.GetComponent<VolumeTrigger>() != null)
				{
					continue;
				}
				else
				{				
					float distance = Hit.distance;
					if (distance > Skin)
					{
						deltaY = distance * direction - Skin * direction;
					}
					else
					{
						deltaY = 0;
					}

					Grounded = true;
					break;
				}
			}
		}
		return deltaY;
	}

//Check for horizontal collisions in movementdirection
	private float HorizontalCollisions(float deltaX)
	{
		SideCollision = false;

		for (int i = 0; i <= SideDivisions; i++)
		{
			float direction = Mathf.Sign(deltaX);
			float RayOriginY = Collider.bounds.center.y + Collider.bounds.extents.y - Collider.bounds.extents.y * 2 / SideDivisions * i;
			float RayOriginX = Collider.bounds.center.x + Collider.bounds.extents.x * direction;
			Debug.DrawRay(new Vector2(RayOriginX, RayOriginY), new Vector2(direction, 0));

			if (Physics.Raycast(new Vector2(RayOriginX, RayOriginY), Vector2.right * direction, out Hit, Mathf.Abs(deltaX) + Skin))
			{
				if (Hit.collider.gameObject.GetComponent<VolumeTrigger>() != null)
				{
					continue;
				}
				else
				{				
					float distance = Hit.distance;
					if (distance > Skin)
					{
						deltaX = distance * direction - Skin * direction;
					}
					else
					{
						deltaX = 0;
					}

					SideCollision = true;
					break;
				}
			}
		}

		return deltaX;
	}

	//Check for diagonal collisions if the character is ungrounded and in movement
	private float DiagonalCollisions(float deltaX, float deltaY)
	{
		Vector3 direction = new Vector3(deltaX, deltaY);
		Vector3 origin = new Vector3(Collider.bounds.center.x + Collider.bounds.extents.x * Mathf.Sign(deltaX), Collider.bounds.center.y + Collider.bounds.extents.y * Mathf.Sign(deltaY));
		Debug.DrawRay(origin, direction.normalized);
		if (Physics.Raycast(origin, direction.normalized, out Hit, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY)) && Hit.collider.gameObject.GetComponent<AbstractTrigger>() == null)
		{
			Grounded = true;
			deltaY = 0;
		}

		return deltaY;
	}

	////////////////////////////////////////////////////////////////////

	//[HideInInspector]
	public bool								Grounded;
	//[HideInInspector]
	public bool 							SideCollision;

	////////////////////////////////////////////////////////////////////

	private Collider 						Collider;
	private Vector2 						MoveTransform;
	private int 							SideDivisions = 4;
	private float 							Skin = .005f;
	private RaycastHit 						Hit;
}
