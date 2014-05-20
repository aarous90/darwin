using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		
		if (camera == null)
		{
			throw new UnityException("No camera to control is attached!");
		}
		
		Initialize();

		CameraManager.Get().Add(this);
	}
	
	// Update is called once per frame
	void Update()
	{
		cameraOffset = 
			right * RightOffset + 
			front * -DistanceOffset + 
			up * HeightOffset;

		if (owner != null && owner.GetCharacter() != null)
		{
			LookAt(owner.GetCharacter().transform.position);
		}
		else
		{
			LookAt(characterPosition);
		}
	}

	void LookAt(Vector3 position)
	{
		transform.position = position + cameraOffset;
		Vector3 lookAt = characterPosition = position;
		lookAt.x = transform.position.x;
		transform.LookAt(lookAt);
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		owner = PlayerManager.Get().GetPlayer(PlayerIndex);

		right = transform.right.normalized;

		front = transform.forward.normalized;

		up = transform.up.normalized;
		
		cameraOffset = 
			right * RightOffset + 
			front * -DistanceOffset + 
			up * HeightOffset;
	}

	////////////////////////////////////////////////////////////////////

	public int PlayerIndex = 0;
	public float RightOffset = 5f;
	public float DistanceOffset = 5f;
	public float HeightOffset = 1.5f;

	////////////////////////////////////////////////////////////////////

	Player owner;
	Vector3 cameraOffset;
	Vector3 front;
	Vector3 up;
	Vector3 right;

	Vector3 characterPosition = new Vector3();
}
