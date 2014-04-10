using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundController : MonoBehaviour, IInputListener
{

		// Use this for initialization
		void Start ()
		{
				UnityEngine.Object.DontDestroyOnLoad (this);
				GlobalInput.RegisterListener (InputManager.InputCategory.Ground, this);
				CharacterController = GetComponent<CharacterController> ();

				LookRight = transform.rotation;
				LookLeft = LookRight * Quaternion.Euler(0, 180, 0); 
		}
	
		// Update is called once per frame
		void Update ()
		{
				Move ();
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

			if (AxisInUse.ContainsKey (InputStringMapping.GroundInputMapping.P1_L_Step) && AxisInUse.ContainsKey (InputStringMapping.GroundInputMapping.P1_R_Step)) {
				if (Math.Abs (AxisInUse [InputStringMapping.GroundInputMapping.P1_L_Step] - AxisInUse [InputStringMapping.GroundInputMapping.P1_R_Step]) <= 0.05) {
					if (CharacterController.isGrounded) {
					TriggeredJump = true;
					AxisInUse.Clear();
					}
				}
			}

				if (axisName == InputStringMapping.GroundInputMapping.P1_L_Step) {
				TrigL = true;	
				if (TrigR) {
					TakeStep (true);
					TrigR = false;
				} else {
					TakeStep (false);
				}
			}

						if (axisName == InputStringMapping.GroundInputMapping.P1_R_Step) {
								TrigR = true;	
								if (TrigL) {
										TakeStep (true);
										TrigL = false;
								} else {
										TakeStep (false);
								}
					
					
					
						}
						m_MaxAxis.Remove (axisName);
				}

		
		}
	
		public void OnMovement (string moveName, int x, int y)
		{
	
		}

		public void Move ()
		{

		if (CharacterController.isGrounded) {
			if (MoveDirection.x > 0) {
				MoveDirection.x -= MoveDirection.x * 0.5f;
			} 
			if (MoveDirection.x < 0) {
				MoveDirection.x -= MoveDirection.x * 0.5f;
			} 
		}
				
						if (TriggeredJump) {
						MoveDirection.x=MoveDirection.x*0.1f;					
							Jump ();
								
						}
				

				MoveDirection.y -= Gravity * Time.deltaTime;
				CharacterController.Move (MoveDirection * Time.deltaTime);

	
	
		}

		public void TakeStep (bool dstep)
	{		
				if (CharacterController.isGrounded) {
						if (Input.GetAxis (InputStringMapping.GroundInputMapping.P1_NavigateHorizontal) > 0.1) {
								transform.rotation = LookRight; 
								if (dstep) {
										MoveDirection.x = MovementSpeed*2;
								} else {
										MoveDirection.x = MovementSpeed;
								}
						}
						if (Input.GetAxis (InputStringMapping.GroundInputMapping.P1_NavigateHorizontal) < -0.1) {
								transform.rotation = LookLeft; 
								if (dstep) {
									MoveDirection.x = -MovementSpeed*2;
								} else {
									MoveDirection.x = -MovementSpeed;
								}
						}
				
				}
		}

		public void Jump ()
		{
		TriggeredJump = false;
		MoveDirection.y = JumpSpeed;
		}

		private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float> ();
		private Dictionary<string, float>		AxisInUse = new Dictionary<string, float> ();
	
		////////////////////////////////////////////////////////
		public InputManager						GlobalInput;
		CharacterController 					CharacterController;
		Vector3                                 MoveDirection = Vector3.zero;
		bool									TriggeredJump = false;
		bool    								TrigL = false;
		bool 									TrigR = false;
		Quaternion								LookRight;
		Quaternion								LookLeft;
		public float							Gravity = 20;
		public float							MovementSpeed = 1;
		public float							MaxMovementSpeed = 100;
		public float							JumpSpeed = 10;
		public float							AxisThreshold = 0;
		public float							AxisMax = 0.9f;

		// not implemented
		float 									JumpTime;
		float 									AirTime;
}
