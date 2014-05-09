using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : IController
{
	public WaterController(int joystickID)
	{
		PID = joystickID;
	}

	private void Swim(Vector2 SwimDir, bool seq)
	{
		currentCharacter.SetDirection(SwimDir);
		currentCharacter.Sequence = seq;
		currentCharacter.Swim(1);
	}


#region IController implementation

	public override void Initialize(ICharacter character)
	{
		if (character is WaterCharacter)
		{
			this.currentCharacter = character as WaterCharacter;
		}
		else
		{
			throw new ArgumentException("Invalid character type!");
		}
	}

#endregion

// Use this for initialization
	public override void Start()
	{

	}

// Update is called once per frame
	public override void Update()
	{

	}

	public override void FixedUpdate()
	{

// Left Analog Stick
		StickInput_1.x = Input.GetAxis("L_XAxis_" + PID);
		StickInput_1.y = Input.GetAxis("L_YAxis_" + PID);
		if (StickInput_1.magnitude < deadzone)
		{
			StickInput_1 = Vector2.zero;
			if (L_Axis == true)
			{
				L_Axis = false;
			}
		}
		else
		{
			if (L_Axis == false)
			{
				L_Stick_Time = Time.time;
				L_Stroke = StickInput_1;
				L_Axis = true;
			}
		}

// Right Analog Stick
		StickInput_2.x = Input.GetAxis("R_XAxis_" + PID);
		StickInput_2.y = Input.GetAxis("R_YAxis_" + PID);
		if (StickInput_2.magnitude < deadzone)
		{
			StickInput_2 = Vector2.zero;
			if (R_Axis == true)
			{
				R_Axis = false;
			}
		}
		else
		{
			if (R_Axis == false)
			{
				R_Stick_Time = Time.time;
				R_Stroke = StickInput_2;
				R_Axis = true;
			}
		}

//Check for simultaneous stick input and swim accordingly
		if (L_Stick_Time != 0 && R_Stick_Time != 0)
		{
			if (Math.Abs(L_Stick_Time - R_Stick_Time) <= TimeTolerance)
			{
				Res_Stroke = L_Stroke + R_Stroke;
				Swim(Res_Stroke, true);
				L_Stroke = Vector2.zero;
				R_Stroke = Vector2.zero;
				Res_Stroke = Vector2.zero;
			} 

			L_Stick_Time = 0;
			R_Stick_Time = 0;

			if (L_Stroke != Vector2.zero)
			{
				Swim(L_Stroke, false);
				L_Stroke = Vector2.zero;
			}
			if (R_Stroke != Vector2.zero)
			{
				Swim(R_Stroke, false);
				R_Stroke = Vector2.zero;

			}
		}
		else
		{
			if (L_Stroke != Vector2.zero)
			{
				Swim(L_Stroke, false);
				L_Stroke = Vector2.zero;
			}
			if (R_Stroke != Vector2.zero)
			{
				Swim(R_Stroke, false);
				R_Stroke = Vector2.zero;

			}
		}


	}

	////////////////////////////////////////////////////////////////////

	public float 							deadzone = 0.9f;
	public float							AxisThreshold = 0;
	public float							AxisMax = 0.75f;
	public float							TimeTolerance = 0.1f;

	////////////////////////////////////////////////////////////////////

	WaterCharacter 							currentCharacter;
	int 									PID;
	Vector2 								StickInput_1;
	Vector2 								StickInput_2;
	Vector2									L_Stroke;
	Vector2 								R_Stroke;
	Vector2 								Res_Stroke;
	bool									L_Axis;
	bool									R_Axis;
	float 									L_Stick_Time;
	float 									R_Stick_Time;

}
