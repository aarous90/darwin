﻿using UnityEngine;
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
			if (Input.GetKey("joystick 1 button "+i))
			{
				print("Button " + i + " is pressed!");
			}
		}
		print("Axis h: " + Input.GetAxisRaw("Horizontal"));
		print("Axis v: " + Input.GetAxisRaw("Vertical"));
	}
}
