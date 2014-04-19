using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerManager : MonoBehaviour
{

	public static ControllerManager Get()
	{
		GameObject manager = GameObject.Find("ControllerManager");
		if (manager != null)
		{
			return manager.GetComponent<ControllerManager>();
		}
		return null;
	}

	// Use this for initialization
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Initialize();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void FixedUpdate()
	{

	}

	////////////////////////////////////////////////////////////////////

	public Dictionary<uint, MovementController> GetControllers()
	{
		return new Dictionary<uint, MovementController>(joysticks);
	}

	void Initialize()
	{
		uint i = 0;
		foreach (string joystick in Input.GetJoystickNames())
		{
			uint ID = i++;
			joysticks.Add(ID, new MovementController(joystick, ID));
		}
	}

	Dictionary<uint, MovementController> joysticks = new Dictionary<uint, MovementController>();

}
