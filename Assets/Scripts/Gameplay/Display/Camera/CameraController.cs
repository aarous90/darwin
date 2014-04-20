using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Initialize();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (owner.GetCharacter() is MonoBehaviour)
		{
			MonoBehaviour character = owner.GetCharacter() as MonoBehaviour;
			transform.position = character.transform.position + cameraOffset;
			Vector3 lookAt = character.transform.position;
			lookAt.x = transform.position.x;
			transform.LookAt(lookAt);
		}
		else
		{
			transform.position = new Vector3(cameraOffset.x, cameraOffset.y, cameraOffset.z);
			transform.LookAt(new Vector3());
		}
	}

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	void Initialize()
	{
		owner = PlayerManager.Get().GetPlayer(PlayerIndex);
		cameraOffset = transform.right.normalized * RightOffset + transform.forward.normalized * -DistanceOffset + transform.up.normalized * HeightOffset;
		CharacterSpawn spawn = CharacterManager.Get().Spawners[(int)PlayerIndex];
		if (spawn != null)
		{
			transform.position = spawn.transform.position + cameraOffset;
			Vector3 lookAt = spawn.transform.position;
			lookAt.x = transform.position.x;
			transform.LookAt(lookAt);
		}
		else
		{
			transform.position = new Vector3(10, 0, 10);
			transform.LookAt(new Vector3());
		}
	}

	////////////////////////////////////////////////////////////////////

	public uint PlayerIndex = 0;

	public float RightOffset = 5f;

	public float DistanceOffset = 5f;

	public float HeightOffset = 1.5f;

	////////////////////////////////////////////////////////////////////

	Player owner;

	Vector3 cameraOffset;
}
