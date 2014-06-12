using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void OnControllerConnectedHandler(int id, MovementController controller);
public delegate void OnControllerDisconnectedHandler(int id, MovementController controller);

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
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	void FixedUpdate()
	{
		if(joysticks.Count==0){
			Initialize();
		}
		else if (Input.GetJoystickNames().Length > joysticks.Count)
		{
			joysticks.Clear();
			Initialize();
			int max = MaximumUsable;
			MaximumUsable = max;
		}
		foreach (var controller in usedJoysticks)
		{
			controller.Value.FixedUpdate();
		}
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Initialize the controllers by fetching joystick names known to unity.
	/// </summary>
	void Initialize()
	{
		int i = 0;

		foreach (string joystick in Input.GetJoystickNames())
		{
			int ID = i++;
			JoystickConnected(ID, joystick);
		}

		if (Input.GetJoystickNames().Length < 2)
		{
			JoystickConnected(i, "Keyboard");
		}
	}

	void JoystickConnected(int id, string joystickName)
	{
		MovementController mc;
		joysticks.Add(id, mc = new MovementController(joystickName, id));
		ControllerConnectedEvent(id, mc);
	}
	
	void JoystickDisconnected(int id)
	{
		ControllerDisconnectedEvent(id, joysticks[id]);
		joysticks.Remove(id);
	}

	////////////////////////////////////////////////////////////////////

	public int AvailabeJoystickCount
	{
		get 
		{
			return joysticks.Count;
		}
	}

	public int MaximumUsable
	{
		get
		{
			return maximumUsable;
		}
		set
		{
			if (value > 0 && value <= joysticks.Count)
			{
				maximumUsable = value;
				usedJoysticks.Clear();
				for (int i = 0; i < maximumUsable; i++)
				{
					usedJoysticks.Add(i, joysticks[i]);
				}
			}
		}
	}

	public Dictionary<int, MovementController> UsedJoysticks
	{
		get
		{
			return usedJoysticks;
		}
	}

	////////////////////////////////////////////////////////////////////
	
	public event OnControllerConnectedHandler ControllerConnectedEvent;

	public event OnControllerDisconnectedHandler ControllerDisconnectedEvent;

	////////////////////////////////////////////////////////////////////

	int maximumUsable;

	/// <summary>
	/// The used joysticks.
	/// </summary>
	Dictionary<int, MovementController> usedJoysticks = new Dictionary<int, MovementController>();

	/// <summary>
	/// The joysticks found on initalize.
	/// </summary>
	Dictionary<int, MovementController> joysticks = new Dictionary<int, MovementController>();

}
