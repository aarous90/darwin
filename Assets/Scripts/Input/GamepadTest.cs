using UnityEngine;
using System;

public class GamepadTest : MonoBehaviour 
{

	// Use this for initialization
	void Start() 
	{
		foreach(string s in Input.GetJoystickNames())
		{
			print(s);
		}


	}
	
	// Update is called once per frame
	void Update() 
	{
		for (int i = 0; i < 20; ++i)
		{
			//P1
			if (Input.GetKey("joystick 1 button "+i))
			{
				print("Joystick 1 Button " + i + " is pressed!");
			}

            //P2
//			if (Input.GetKey("joystick 2 button "+i))
//			{
//				print("Joystick 2 Button " + i + " is pressed!");
//			}
		}
		//P1
		print("1_L_Axis h: " + Input.GetAxisRaw("L_XAxis_0"));
		print("1_L_Axis v: " + Input.GetAxisRaw("L_YAxis_0"));
		print("1_R_Axis h: " + Input.GetAxisRaw("R_XAxis_0"));
		print("1_R_Axis v: " + Input.GetAxisRaw("R_YAxis_0"));
		print("1_Axis LT: " + Input.GetAxisRaw("L_Trigger_0"));
		print("1_Axis RT: " + Input.GetAxisRaw("R_Trigger_0"));

		//P2
//		print("2_L_Axis h: " + Input.GetAxisRaw("L_XAxis_1"));
//		print("2_L_Axis v: " + Input.GetAxisRaw("L_YAxis_1"));
//		print("2_R_Axis h: " + Input.GetAxisRaw("R_XAxis_1"));
//		print("2_R_Axis v: " + Input.GetAxisRaw("R_YAxis_1"));
//		print("2_Axis LT: " + Input.GetAxisRaw("L_Trigger_1"));
//		print("2_Axis RT: " + Input.GetAxisRaw("R_Trigger_1"));
	}
}
