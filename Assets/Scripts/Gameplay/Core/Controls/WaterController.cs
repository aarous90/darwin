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
		
				//Length of Raycast to check ground considering collider offset
				RayLength = collider.bounds.size.y / 2 - Math.Abs (transform.position.y - collider.bounds.center.y);
		}
	
		// Update is called once per frame
		void Update ()
		{
		}
	
		void FixedUpdate ()
		{		
		
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
						if (!AxisInUse.ContainsKey (axisName)) {
								AxisInUse.Add (axisName, Time.time);
						} else {
								AxisInUse [axisName] = Time.time;
						}
						return;
				}
		
				float value;
		
				if ((Math.Abs (axisValue) < AxisMax && m_MaxAxis.TryGetValue (axisName, out value))) {
			
						if (AxisInUse.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1) && AxisInUse.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2)) {
								if (Math.Abs (AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1] - AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2]) <= 0.5) {
										MoveHorizontal (true, axisValue);
										AxisInUse.Clear ();
										m_MaxAxis.Clear ();
								}
						}

						if (AxisInUse.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateVertical_1) && AxisInUse.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateVertical_2)) {
								if (Math.Abs (AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_1] - AxisInUse [InputStringMapping.WaterInputMapping.P1_NavigateVertical_2]) <= 0.5) {
										MoveVertical (true, axisValue);
										AxisInUse.Clear ();
										m_MaxAxis.Clear ();
								}
						}
			
						if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1 && m_MaxAxis.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_1)) {
								MoveHorizontal (false, axisValue);
						}

						if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2 && m_MaxAxis.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateHorizontal_2)) {
								MoveHorizontal (false, axisValue);
						}

						if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_1 && m_MaxAxis.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateVertical_1)) {
								MoveVertical (false, axisValue);
						}
			
						if (axisName == InputStringMapping.WaterInputMapping.P1_NavigateVertical_2 && m_MaxAxis.ContainsKey (InputStringMapping.WaterInputMapping.P1_NavigateVertical_2)) {
								MoveVertical (false, axisValue);
						}
				}
				m_MaxAxis.Remove (axisName);
		}
	
		public void OnMovement (string moveName, int x, int y)
		{
		
		}
	
		public void MoveHorizontal (bool dstep, float value)
		{
				Flip (value);
				if (rigidbody.velocity.magnitude < MaxSpeed) {
						if (dstep) {
								print ("MH2");
									//rigidbody.AddForce (Vector3.right * value * MovementSpeed * 2);
				rigidbody.velocity = rigidbody.velocity + (Vector3.right*MovementSpeed * value);
						} else {
								print ("MH1");
								//rigidbody.AddForce (Vector3.right * value * MovementSpeed);
				rigidbody.velocity = rigidbody.velocity + (Vector3.right *MovementSpeed* value * 0.5f);
						}
				}
		}

		public void MoveVertical (bool dstep, float value)
		{		
				if (rigidbody.velocity.magnitude < MaxSpeed) {
						if (dstep) {
								print ("MV2");
								//rigidbody.AddForce (Vector3.up * value * MovementSpeed * 2*-1);
				rigidbody.velocity = rigidbody.velocity + (Vector3.up *MovementSpeed * -value);
						} else {
								print ("MV1");
								//rigidbody.AddForce (Vector3.up * value * MovementSpeed*-1);
				rigidbody.velocity = rigidbody.velocity + (Vector3.up *MovementSpeed * -value * 0.5f);
						}
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

		private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float> ();
		private Dictionary<string, float>		AxisInUse = new Dictionary<string, float> ();
	
		////////////////////////////////////////////////////////
		public InputManager						GlobalInput;
		float 									RayLength;
		Quaternion								LookRight;
		Quaternion								LookLeft;
		public float							Gravity = 9.81f;
		public float							MovementSpeed = 100;
		public float							MovementForce = 5;
		public float							MaxSpeed = 10;
		public float							JumpSpeed = 10;
		public float							AxisThreshold = 0.1f;
		public float							AxisMax = 0.3f;
}
