using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : MonoBehaviour, IInputListener
{
	
	// Use this for initialization
	void Start ()
	{
		UnityEngine.Object.DontDestroyOnLoad (this);
		GlobalInput.RegisterListener (InputManager.InputCategory.Water, this);
		
		LookRight = transform.rotation;
		LookLeft = LookRight * Quaternion.Euler (0, 180, 0); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void FixedUpdate ()
	{
		
		rigidbody.AddForce (Vector3.right * HorizontalForce * MovementSpeed);
		rigidbody.AddForce (Vector3.up * VerticalForce * MovementSpeed);
		VerticalForce *= 1.0f - Drag;
		HorizontalForce *= 1.0f - Drag;
		
		
		Velocity = rigidbody.velocity;
		Velocity.x *= 0.99f;
		Velocity.y *= 0.99f;
		rigidbody.velocity = Velocity;
		
		
		if (Mathf.Abs (rigidbody.velocity.x) > MaxSpeed) {
			Velocity = rigidbody.velocity;
			Velocity.x = Mathf.Sign (rigidbody.velocity.x) * MaxSpeed;
			rigidbody.velocity = Velocity;
		}
		if (Mathf.Abs (rigidbody.velocity.y) > MaxSpeed) {
			Velocity = rigidbody.velocity;
			Velocity.y = Mathf.Sign (rigidbody.velocity.y) * MaxSpeed;
			rigidbody.velocity = Velocity;
		}
		
	}
	
	public void OnButtonUp (string button)
	{
		
	}
	
	public void OnButtonPressed (string button)
	{
		
	}
	
	public void OnButtonDown (string button)
	{
		test ();
	}
	
	public void OnAxis (string axisName, float axisValue)
	{
		// Left Analog Stick
		StickInput_1.x = Input.GetAxis (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1);
		StickInput_1.y = Input.GetAxis (InputStringMapping.WaterInputMapping.P1_NavigateVertical_1);
		if (StickInput_1.magnitude < deadzone) {
			StickInput_1 = Vector2.zero;
			if (AxisInUse.ContainsKey (axisName)) {
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1] = false;
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_1] = false;
			}
		} else {
			if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1 || axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_1) {
				if (!AxisInUse.ContainsKey (axisName)) {
					AxisInUse.Add (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1, true);
					AxisInUse.Add (InputStringMapping.WaterInputMapping.P1_NavigateVertical_1, true);
					Move (false, StickInput_1.x, StickInput_1.y);
				} else {
					if (AxisInUse [axisName] == false) {
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1] = true;
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_1] = true;
						Move (false, StickInput_1.x, StickInput_1.y);
					}
				}
			}
		}
		// Right Analog Stick
		StickInput_2.x = Input.GetAxis (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2);
		StickInput_2.y = Input.GetAxis (InputStringMapping.WaterInputMapping.P1_NavigateVertical_2);
		if (StickInput_2.magnitude < deadzone) {
			StickInput_2 = Vector2.zero;
			if (AxisInUse.ContainsKey (axisName)) {
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2] = false;
				AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_2] = false;
			}
		} else {
			if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2 || axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_2) {
				if (!AxisInUse.ContainsKey (axisName)) {
					AxisInUse.Add (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2, true);
					AxisInUse.Add (InputStringMapping.WaterInputMapping.P1_NavigateVertical_2, true);
					Move (false, StickInput_2.x, StickInput_2.y);
				} else {
					if (AxisInUse [axisName] == false) {
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2] = true;
						AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_2] = true;
						Move (false, StickInput_2.x, StickInput_2.y);
					}
				}
			}
		}
	}
	
	public void OnMovement (string moveName, int x, int y)
	{
		
	}
	
	public void Move (bool dstep, float x, float y)
	{		
		Flip (x);
		if (dstep) {
			MaxSpeed = MaxSpeed_2;
			HorizontalForce += 0.5f * MovementSpeed * Math.Sign (x);
			VerticalForce += 0.5f * MovementSpeed * Math.Sign (y) * -1;
			
		} else {
			MaxSpeed = MaxSpeed_1;
			HorizontalForce += 0.5f * MovementSpeed * Math.Sign (x);
			VerticalForce += 0.5f * MovementSpeed * Math.Sign (y) * -1;
		}
	}
	
	void Flip (float h)
	{
		if (h > 0) {
			transform.rotation = LookRight;
		}
		if (h < 0) {
			transform.rotation = LookLeft; 
		}
	}
	
	void test ()
	{
	}
	
	private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float> ();
	private Dictionary<string, bool>		AxisInUse = new Dictionary<string, bool> ();
	
	////////////////////////////////////////////////////////
	public InputManager						GlobalInput;
	float 									RayLength;
	float									MaxSpeed;
	float 									deadzone = 0.75f;
	float									HorizontalForce;
	float									VerticalForce;
	Quaternion								LookRight;
	Quaternion								LookLeft;
	Vector3 								Velocity;
	Vector2 								StickInput_1;
	Vector2 								StickInput_2;
	public float 							Drag = 0.3f;
	public float							MovementSpeed = 10;
	public float 							MaxSpeed_1 = 2;
	public float 							MaxSpeed_2 = 5;
	public float							JumpSpeed = 10;
	public float							AxisThreshold = 0;
	public float							AxisMax = 0.9f;
}
