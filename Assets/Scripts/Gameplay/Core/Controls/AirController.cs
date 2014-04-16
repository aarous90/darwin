using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AirController : MonoBehaviour, IInputListener
{
	
	// Use this for initialization
	void Start ()
	{
		UnityEngine.Object.DontDestroyOnLoad (this);
		GlobalInput.RegisterListener (InputManager.InputCategory.Ground, this);
		
		LookRight = transform.rotation;
		LookLeft = LookRight * Quaternion.Euler (0, 180, 0); 
		
		//Length of Raycast to check ground considering collider offset
		RayLength = collider.bounds.size.y / 2 - Math.Abs (transform.position.y - collider.bounds.center.y);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void FixedUpdate ()
	{		
		//Jump
		if (TriggeredJump) {
			Jump ();
		}
		
		//Apply own Gravity
		rigidbody.AddForce (-Vector3.up * Gravity * rigidbody.mass);
		
	}
	
	public void OnButtonUp (string button)
	{
		
	}
	
	public void OnButtonPressed (string button)
	{
		
	}
	
	public void OnButtonDown (string button)
	{
		
	}
	
	public void OnAxis (string axisName, float axisValue)
	{
		
		if (Math.Abs (axisValue) > AxisMax && !m_MaxAxis.ContainsKey (axisName)) {
			m_MaxAxis.Add (axisName, axisValue);
			if (axisName == InputStringMapping.GroundInputMapping.P1_NavigateHorizontal) {
				HAxis *= axisValue;	
			}
			if (!AxisInUse.ContainsKey (axisName)) {
				AxisInUse.Add (axisName, Time.time);
			} else {
				AxisInUse [axisName] = Time.time;
			}
			return;
		}
		
		float value;
		
		if ((Math.Abs (axisValue) < AxisMax && m_MaxAxis.TryGetValue (axisName, out value))) {
			
			if (AxisInUse.ContainsKey (InputStringMapping.GroundInputMapping.P1_L_Step) && AxisInUse.ContainsKey (InputStringMapping.GroundInputMapping.P1_R_Step)) {
				if (Math.Abs (AxisInUse [InputStringMapping.GroundInputMapping.P1_L_Step] - AxisInUse [InputStringMapping.GroundInputMapping.P1_R_Step]) <= 0.05) {
					TriggeredJump = true;
					AxisInUse.Clear ();
					m_MaxAxis.Clear ();
				}
			}
			
			if (axisName == InputStringMapping.GroundInputMapping.P1_L_Step && m_MaxAxis.ContainsKey (InputStringMapping.GroundInputMapping.P1_NavigateHorizontal)) {
				HAxis = m_MaxAxis [(InputStringMapping.GroundInputMapping.P1_NavigateHorizontal)];
				TrigL = true;	
				if (TrigR) {
					Move (true);
					TrigR = false;
				} else {
					Move (false);
				}
			}
			
			if (axisName == InputStringMapping.GroundInputMapping.P1_R_Step && m_MaxAxis.ContainsKey (InputStringMapping.GroundInputMapping.P1_NavigateHorizontal)) {
				HAxis = m_MaxAxis [(InputStringMapping.GroundInputMapping.P1_NavigateHorizontal)];
				TrigR = true;	
				if (TrigL) {
					Move (true);
					TrigL = false;
				} else {
					Move (false);
				}
				
				
				
			}
			m_MaxAxis.Remove (axisName);
		}
		
		
		
	}
	
	public void OnMovement (string moveName, int x, int y)
	{
		
	}
	
	public void Move (bool dstep)
	{		
		HAxis *= MovementForce;
		Flip (HAxis);
		if (rigidbody.velocity.magnitude < MaxSpeed && IsGrounded () == true) {
			if (dstep) {
				//rigidbody.AddForce (Vector3.right * HAxis * MovementSpeed*2);
				rigidbody.velocity = rigidbody.velocity + (Vector3.right * HAxis);
			} else {
				//rigidbody.AddForce (Vector3.right * HAxis * MovementSpeed);
				rigidbody.velocity = rigidbody.velocity + (Vector3.right * HAxis * 0.5f);
			}
		}
	}
	
	public void Jump ()
	{
		if (IsGrounded ()) {					
			TriggeredJump = false;
			rigidbody.velocity = rigidbody.velocity + (Vector3.up * JumpSpeed);
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
	
	public bool IsGrounded ()
	{
		if (Physics.Raycast (transform.position, -transform.up, RayLength)) {
			Grounded = true;
		} else {
			Grounded = false;
		}
		return Grounded;
	}
	
	private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float> ();
	private Dictionary<string, float>		AxisInUse = new Dictionary<string, float> ();
	
	////////////////////////////////////////////////////////
	public InputManager						GlobalInput;
	bool 									Grounded;
	float 									RayLength;
	float 									HAxis;
	bool									TriggeredJump = false;
	bool    								TrigL = false;
	bool 									TrigR = false;
	Quaternion								LookRight;
	Quaternion								LookLeft;
	public float							Gravity = 9.81f;
	public float							MovementSpeed = 10;
	public float							MovementForce = 5;
	public float							MaxSpeed = 10;
	public float							JumpSpeed = 10;
	public float							AxisThreshold = 0;
	public float							AxisMax = 0.9f;
	
	// not implemented yet
	float 									JumpTime;
	float 									AirTime;
}
