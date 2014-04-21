using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : IController, IInputListener
{
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

	// Use this for initialization
	public override void Start()
	{
		InputManager.Get().RegisterListener(InputManager.InputCategory.Ground, this);

		LookRight = currentCharacter.transform.rotation;
		LookLeft = LookRight * Quaternion.Euler(0, 180, 0); 

		//Length of Raycast to check ground considering collider offset
		RayLength = currentCharacter.collider.bounds.size.y / 2 - 
			Math.Abs(currentCharacter.transform.position.y - currentCharacter.collider.bounds.center.y);
		RayOffset = Vector3.right * (currentCharacter.collider.bounds.size.x / 2 - 
		                             Math.Abs(currentCharacter.transform.position.x - currentCharacter.collider.bounds.center.x));
	}			

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void FixedUpdate()
	{		
		if (IsGrounded())
		{
			currentCharacter.rigidbody.AddForce(Vector3.right * MovementForce * MovementSpeed);
			MovementForce *= 1.0f - Drag;

		}

		if (Mathf.Abs(currentCharacter.rigidbody.velocity.x) > MaxSpeed)
		{
			Velocity = currentCharacter.rigidbody.velocity;
			Velocity.x = Mathf.Sign(currentCharacter.rigidbody.velocity.x) * MaxSpeed;
			currentCharacter.rigidbody.velocity = Velocity;
		}

		//Jump
		if (TriggeredJump)
		{
			Jump();
		}

		//Apply own Gravity
		currentCharacter.rigidbody.AddForce(-Vector3.up * Gravity * currentCharacter.rigidbody.mass);

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

		if (Math.Abs(axisValue) > AxisMax && !m_MaxAxis.ContainsKey(axisName))
		{
			m_MaxAxis.Add(axisName, axisValue);
			if (axisName == InputStringMapping.GroundInputMapping.P1_NavigateHorizontal)
			{
				HAxis = axisValue;
				Flip(HAxis);
			}
			if (!AxisInUse.ContainsKey(axisName))
			{
				AxisInUse.Add(axisName, Time.time);
			}
			else
			{
				AxisInUse [axisName] = Time.time;
			}
			return;
		}

		float value;

		if ((Math.Abs(axisValue) < AxisMax && m_MaxAxis.TryGetValue(axisName, out value)))
		{

			if (AxisInUse.ContainsKey(InputStringMapping.GroundInputMapping.P1_L_Step) && AxisInUse.ContainsKey(InputStringMapping.GroundInputMapping.P1_R_Step))
			{
				if (Math.Abs(AxisInUse [InputStringMapping.GroundInputMapping.P1_L_Step] - AxisInUse [InputStringMapping.GroundInputMapping.P1_R_Step]) <= 0.05)
				{
					TriggeredJump = true;
					AxisInUse.Clear();
					m_MaxAxis.Clear();
				}
			}

			if (axisName == InputStringMapping.GroundInputMapping.P1_L_Step && m_MaxAxis.ContainsKey(InputStringMapping.GroundInputMapping.P1_NavigateHorizontal))
			{
				TrigL = true;	
				if (TrigR)
				{
					Move(true);
					TrigR = false;
				}
				else
				{
					Move(false);
				}
			}

			if (axisName == InputStringMapping.GroundInputMapping.P1_R_Step && m_MaxAxis.ContainsKey(InputStringMapping.GroundInputMapping.P1_NavigateHorizontal))
			{
				TrigR = true;	
				if (TrigL)
				{
					Move(true);
					TrigL = false;
				}
				else
				{
					Move(false);
				}



			}
			m_MaxAxis.Remove(axisName);
		}



	}

	public void OnMovement(string moveName, int x, int y)
	{

	}

	public void Move(bool dstep)
	{
		if (IsGrounded())
		{
			if (dstep)
			{
				MaxSpeed = MaxSpeed_2;
				MovementForce += 0.5f * MovementSpeed * Math.Sign(HAxis);
			}
			else
			{
				MaxSpeed = MaxSpeed_1;
				MovementForce += 0.5f * MovementSpeed * Math.Sign(HAxis);
			}
		}
	}

	public void Jump()
	{
		if (IsGrounded())
		{					
			currentCharacter.rigidbody.velocity = currentCharacter.rigidbody.velocity + (Vector3.up * JumpSpeed);
			TriggeredJump = false;
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

	public bool IsGrounded()
	{
		if (Physics.Raycast(currentCharacter.transform.position, -currentCharacter.transform.up, RayLength) || 
		    Physics.Raycast(currentCharacter.transform.position + RayOffset, -currentCharacter.transform.up, RayLength) ||
		    Physics.Raycast(currentCharacter.transform.position - RayOffset, -currentCharacter.transform.up, RayLength))
		{
			Grounded = true;
		}
		else
		{
			Grounded = false;
		}
		return Grounded;
	}

	private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float>();
	private Dictionary<string, float>		AxisInUse = new Dictionary<string, float>();

	////////////////////////////////////////////////////////

	bool 									Grounded;
	float 									RayLength;
	Vector3 								RayOffset;
	float 									HAxis;
	float 									MaxSpeed = 0;
	float 									MovementForce;
	Vector3 								Velocity;
	bool									TriggeredJump = false;
	bool    								TrigL = false;
	bool 									TrigR = false;
	Quaternion								LookRight;
	Quaternion								LookLeft;
	public float 							Drag = 0.3f;
	public float							Gravity = 9.81f;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
	public float							MovementSpeed = 10;
	public float							JumpSpeed = 10;
	public float							AxisThreshold = 0;
	public float							AxisMax = 0.9f;

	////////////////////////////////////////////////////////

	GroundCharacter currentCharacter;
}
