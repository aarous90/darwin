using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {


	public static ControllerManager Get()
	{
		GameObject im = GameObject.Find("ControllerManager");
		if (im != null)
		{
			return im.GetComponent<ControllerManager>();
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		UnityEngine.Object.DontDestroyOnLoad(this);
		string[] joystickNames = Input.GetJoystickNames();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
