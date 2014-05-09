using System;
using System.Collections.Generic;
using UnityEngine;

public class AirController : IController
{
	public AirController(int joystickID)
	{
		PID = joystickID;
	}

#region IController implementation

	public override void Initialize(ICharacter character)
	{
		if (character is AirCharacter)
		{
			currentCharacter = character as AirCharacter;
		}
		else
		{
			throw new ArgumentException("Invalid character type!");
		}
	}

#endregion

//Use this for initialization
	public override void Start()
	{

	}			

//Update is called once per frame
	public override void Update()
	{		

	}

	public override void FixedUpdate()
	{	

		currentCharacter.SetDirection(Input.GetAxis("L_XAxis_" + PID));

		if (Input.GetAxis("R_Trigger_" + PID) > AxisMax && R_T == false)
		{
			R_T = true;
			R_T_Time = Time.time;

			if (L_T == true && R_T == true)
			{
				if (Math.Abs(L_T_Time - R_T_Time) <= TimeTolerance)
				{
					currentCharacter.Sequence = true;
					currentCharacter.Fly(Time.deltaTime);
				}
			}
			else
			{
				currentCharacter.Sequence = false;
				currentCharacter.Fly(Time.deltaTime);
			}
		}

		if (Input.GetAxis("L_Trigger_" + PID) > AxisMax && L_T == false)
		{
			L_T = true;
			L_T_Time = Time.time;

			if (L_T == true && R_T == true)
			{
				if (Math.Abs(L_T_Time - R_T_Time) <= TimeTolerance)
				{
					currentCharacter.Sequence = true;
					currentCharacter.Fly(Time.deltaTime);
				}
			}
			else
			{
				currentCharacter.Sequence = false;
				currentCharacter.Fly(Time.deltaTime);
			}
		}

		if (Input.GetAxis("L_Trigger_" + PID) < AxisThreshold)
		{
			L_T = false;
		}

		if (Input.GetAxis("R_Trigger_" + PID) < AxisThreshold)
		{
			R_T = false;
		}


	}

////////////////////////////////////////////////////////////////////

	public float							AxisThreshold = 0.3f;
	public float							AxisMax = 0.9f;
	public float							TimeTolerance = 0.05f;

////////////////////////////////////////////////////////////////////

	AirCharacter 							currentCharacter;
	float    								R_T_Time;
	float 									L_T_Time;
	bool									R_T;
	bool									L_T;
	int 									PID;
}
