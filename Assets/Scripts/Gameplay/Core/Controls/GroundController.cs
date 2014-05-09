using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : IController
{
	public GroundController(int joystickID)
	{
		PID = joystickID;
	}

	private bool CheckSequence(String s)
	{
		bool Seq;

		if (LastUsed == null)
		{
			Seq = false;
		}
		else if (s == LastUsed)
		{
			Seq = false;
		}
		else
		{
			Seq = true;
		}

		LastUsed = s;
		return Seq;
	}

#region IController implementation

	public override void Initialize(ICharacter character)
	{
		if (character is GroundCharacter)
		{
			currentCharacter = character as GroundCharacter;
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
			currentCharacter.Sequence = CheckSequence("R_T");

			if (L_T == true && R_T == true)
			{
				if (Math.Abs(L_T_Time - R_T_Time) <= TimeTolerance)
				{
					currentCharacter.Jump(Time.deltaTime);
				}
				else
				{
					currentCharacter.Move(Time.deltaTime);
				}
			}
			else
			{
				currentCharacter.Move(Time.deltaTime);
			}
		}

		if (Input.GetAxis("L_Trigger_" + PID) > AxisMax && L_T == false)
		{
			L_T = true;
			L_T_Time = Time.time;
			currentCharacter.Sequence = CheckSequence("L_T");

			if (L_T == true && R_T == true)
			{
				if (Math.Abs(L_T_Time - R_T_Time) <= TimeTolerance)
				{
					currentCharacter.Jump(Time.deltaTime);
				}
				else
				{
					currentCharacter.Move(Time.deltaTime);
				}
			}
			else
			{
				currentCharacter.Move(Time.deltaTime);
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

	GroundCharacter 						currentCharacter;
	String									LastUsed;
	int 									PID;
	bool    								R_T;
	bool 									L_T;
	float    								R_T_Time;
	float 									L_T_Time;

}
