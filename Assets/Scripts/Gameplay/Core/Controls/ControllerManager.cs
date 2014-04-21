using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controller manager singleton. Initialises joysticks/gamepads and keeps references about them.
/// TODO: add functionality to find unplugged/replugged joypads?
/// </summary>
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
		Object.DontDestroyOnLoad(this);
		Initialize();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void FixedUpdate()
	{
		foreach (var controller in joysticks)
		{
			controller.Value.FixedUpdate();
		}
	}

	////////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// Returns a copy of the known controllers
	/// </summary>
	public Dictionary<int, MovementController> GetControllers()
	{
		return new Dictionary<int, MovementController>(joysticks);
	}

	/// <summary>
	/// Initialize the controllers by fetching joystick names known to unity.
	/// </summary>
	void Initialize()
	{
		int i = 0;
		foreach (string joystick in Input.GetJoystickNames())
		{
			int ID = i++;
			joysticks.Add(ID, new MovementController(joystick, ID));
		}
	}

	/// <summary>
	/// The joysticks found on initalize.
	/// </summary>
	Dictionary<int, MovementController> joysticks = new Dictionary<int, MovementController>();

}
