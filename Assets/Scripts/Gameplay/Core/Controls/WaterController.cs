using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : IController, IInputListener
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
		GlobalInput.RegisterListener(InputManager.InputCategory.Water, this);

		LookRight = currentCharacter.transform.rotation;
		LookLeft = LookRight * Quaternion.Euler(0, 180, 0); 
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void FixedUpdate()
	{

		currentCharacter.rigidbody.AddForce(Vector3.right * HorizontalForce * MovementSpeed);
		currentCharacter.rigidbody.AddForce(Vector3.up * VerticalForce * MovementSpeed);
		//MovementForce Drag
		VerticalForce *= 1.0f - Drag;
		HorizontalForce *= 1.0f - Drag;

		//Velocity Drag
		Velocity = currentCharacter.rigidbody.velocity;
		Velocity.x *= 0.9f;
		Velocity.y *= 0.9f;
		currentCharacter.rigidbody.velocity = Velocity;

		// set velocity to MaxSpeed if exceeding
		if (Mathf.Abs(currentCharacter.rigidbody.velocity.x) > MaxSpeed)
		{
			Velocity = currentCharacter.rigidbody.velocity;
			Velocity.x = Mathf.Sign(currentCharacter.rigidbody.velocity.x) * MaxSpeed;
			currentCharacter.rigidbody.velocity = Velocity;
		}
		if (Mathf.Abs(currentCharacter.rigidbody.velocity.y) > MaxSpeed)
		{
			Velocity = currentCharacter.rigidbody.velocity;
			Velocity.y = Mathf.Sign(currentCharacter.rigidbody.velocity.y) * MaxSpeed;
			currentCharacter.rigidbody.velocity = Velocity;
		}

	}

	public void OnButtonUp(string button)
	{

	}

	public void OnButtonPressed(string button)
	{

	}

	public void OnButtonDown(string button)
	{

	}

	public void OnAxis(string axisName, float axisValue)
	{

		Vector2 LStroke = Vector2.zero;
		Vector2 RStroke = Vector2.zero;
		Vector2 Stroke = Vector2.zero;

// Left Analog Stick
//				if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1) {
//						StickInput_1.x = axisValue;
//				}
//				if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_1) {
//						StickInput_1.y = axisValue;
//				}
		StickInput_1.x = Input.GetAxis(InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1);
		StickInput_1.y = Input.GetAxis(InputStringMapping.WaterInputMapping.P1_NavigateVertical_1);
		if (StickInput_1.magnitude < deadzone)
		{
			StickInput_1 = Vector2.zero;
			if (AxisInUse.ContainsKey(axisName))
			{
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1] = false;
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_1] = false;
			}
		}
		else
		{
			if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1 || axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_1)
			{
				if (!AxisInUse.ContainsKey(axisName))
				{
					AxisInUse.Add(InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1, true);
					AxisInUse.Add(InputStringMapping.WaterInputMapping.P1_NavigateVertical_1, true);
					lTimer = Time.time;
					LStroke = StickInput_1;
				}
				else
				{
					if (AxisInUse [axisName] == false)
					{
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1] = true;
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_1] = true;
						lTimer = Time.time;
						LStroke = StickInput_1;
					}
				}
			}
		}

// Right Analog Stick
//				if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2) {
//						StickInput_2.x = axisValue;
//				}
//				if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_2) {
//						StickInput_2.y = axisValue;
//				}
		StickInput_2.x = Input.GetAxis(InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2);
		StickInput_2.y = Input.GetAxis(InputStringMapping.WaterInputMapping.P1_NavigateVertical_2);
		if (StickInput_2.magnitude < deadzone)
		{
			StickInput_2 = Vector2.zero;
			if (AxisInUse.ContainsKey(axisName))
			{
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2] = false;
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_2] = false;
			}
		}
		else
		{
			if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2 || axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_2)
			{
				if (!AxisInUse.ContainsKey(axisName))
				{
					AxisInUse.Add(InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2, true);
					AxisInUse.Add(InputStringMapping.WaterInputMapping.P1_NavigateVertical_2, true);
					rTimer = Time.time;
					RStroke = StickInput_2;
				}
				else
				{
					if (AxisInUse [axisName] == false)
					{
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2] = true;
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_2] = true;
						rTimer = Time.time;
						RStroke = StickInput_2;
					}
				}
			}
		}


		if (lTimer != 0 && rTimer != 0)
		{
			if (Math.Abs(lTimer - rTimer) <= 0.1)
			{
				Stroke = LStroke + RStroke;
				Move(true, Stroke.x, Stroke.y);

			} 
			lTimer = 0;
			rTimer = 0;
		}
		else
		{
			Move(false, LStroke.x, LStroke.y);
			Move(false, RStroke.x, RStroke.y);
		}

	}

	public void OnMovement(string moveName, int x, int y)
	{

	}

	public void Move(bool dstep, float x, float y)
	{		
		Flip(x);
		if (dstep)
		{
			MaxSpeed = MaxSpeed_2;
			HorizontalForce += 0.5f * MovementSpeed * Math.Sign(x);
			VerticalForce += 0.5f * MovementSpeed * Math.Sign(y) * -1;

		}
		else
		{
			MaxSpeed = MaxSpeed_1;
			HorizontalForce += 0.5f * MovementSpeed * Math.Sign(x);
			VerticalForce += 0.5f * MovementSpeed * Math.Sign(y) * -1;
		}
	}

	void Flip(float h)
	{
		if (h > 0)
		{
			currentCharacter.transform.rotation = LookRight;
		}
		if (h < 0)
		{
			currentCharacter.transform.rotation = LookLeft; 
		}
	}

	void test()
	{
	}

	private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float>();
	private Dictionary<string, bool>		AxisInUse = new Dictionary<string, bool>();

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
