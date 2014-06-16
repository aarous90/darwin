using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		
		if (camera == null)
		{
			Debug.LogError("No camera to control is attached!");
			return;
		}
		
		Initialize();

		CameraManager.Get().Add(this);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (usedCharacter == null) return;

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
		float camHeight = initialPosition.y;
		// over spawn
		if (position.y - camHeight > 0)
		{
			if (Mathf.Abs(position.y - camHeight) > MaxUpDistance)
			{
				camHeight = initialPosition.y + MaxUpDistance;
			}
			else
				camHeight = position.y;
		}
		// below spawn
		else
		{			
			if (Mathf.Abs(position.y - camHeight) > MaxUpDistance)
			{
				camHeight = initialPosition.y - MaxUpDistance;
			}
			else
				camHeight = position.y;
		}
		transform.position = characterPosition = 
			new Vector3(position.x + cameraOffset.x, camHeight, position.z + cameraOffset.z);
//		Vector3 lookAt = characterPosition = position;
//		lookAt.x = transform.position.x;
//		lookAt.y = initialPosition.y;
//		transform.LookAt(lookAt);
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		owner = PlayerManager.Get().GetPlayer(PlayerIndex);

		owner.GetController().UseCharacterEvent += delegate(MovementController controller, ICharacter character)
		{
			character.SpawnedEvent += delegate(ICharacter spawned, CharacterSpawn spawner) 
			{
				usedCharacter = spawned;
				initialPosition = character.transform.position;
				MaxUpDistance = spawner.MovementOffset;
			};
		};

		initialPosition = characterPosition;

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

	ICharacter usedCharacter;
	Player owner;
	Vector3 cameraOffset;
	Vector3 front;
	Vector3 up;
	Vector3 right;
	Vector3 characterPosition = new Vector3();
	Vector3 initialPosition;
	float MaxUpDistance;
}
