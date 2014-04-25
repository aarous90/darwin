using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : IController
{
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
		

	}


	////////////////////////////////////////////////////////
		
	public InputManager						GlobalInput;
	float 									RayLength;
	float									MaxSpeed;
	float 									deadzone = 0.75f;
	float									HorizontalForce;
	float									VerticalForce;
	float 									lTimer;
	float 									rTimer;
	Quaternion								LookRight;
	Quaternion								LookLeft;
	Vector3 								Velocity;
	Vector2 								StickInput_1;
	Vector2 								StickInput_2;
	public float 							Drag = 0.3f;
	public float							MovementSpeed = 10;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
	public float							AxisThreshold = 0;
	public float							AxisMax = 0.9f;
	
	////////////////////////////////////////////////////////
		
	WaterCharacter 							currentCharacter;
}
