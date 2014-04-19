using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundController : IController, IInputListener
{
	#region IController implementation
	
	public void Initialize(ICharacter character)
	{
		if (character is GroundCharacter)
		{
			this.currentCharacter = character as GroundCharacter;
		}
		else
		{
			throw new ArgumentException("Invalid character type!");
		}
	}
	
	#endregion

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
				if (IsGrounded ()) {
						rigidbody.AddForce (Vector3.right * MovementForce * MovementSpeed);
						MovementForce *= 1.0f - Drag;

				}

				if (Mathf.Abs (rigidbody.velocity.x) > MaxSpeed) {
						Velocity = rigidbody.velocity;
						Velocity.x = Mathf.Sign (rigidbody.velocity.x) * MaxSpeed;
						rigidbody.velocity = Velocity;
				}

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
				Flip (HAxis);
				if (dstep) {
						MaxSpeed = MaxSpeed_2;
						MovementForce += 0.5f * MovementSpeed * Math.Sign (HAxis);
				} else {
						MaxSpeed = MaxSpeed_1;
						MovementForce += 0.5f * MovementSpeed * Math.Sign (HAxis);
				}
		}

		public void Jump ()
		{
				if (IsGrounded ()) {					
						rigidbody.velocity = rigidbody.velocity + (Vector3.up * JumpSpeed);
						TriggeredJump = false;
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
