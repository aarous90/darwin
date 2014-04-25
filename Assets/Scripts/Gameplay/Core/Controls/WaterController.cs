using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : IController
{
		public WaterController (int joystickID)
		{
				PID = joystickID;
		}


	#region IController implementation
	
		public override void Initialize (ICharacter character)
		{
				if (character is WaterCharacter) {
						this.currentCharacter = character as WaterCharacter;
				} else {
						throw new ArgumentException ("Invalid character type!");
				}
		}
	
	#endregion

// Use this for initialization
		public override void Start ()
		{

		}

		// Update is called once per frame
		public override void Update ()
		{

		}

		public override void FixedUpdate ()
		{
				L_Stroke = Vector2.zero;
				R_Stroke = Vector2.zero;
				Res_Stroke = Vector2.zero;
		
				// Left Analog Stick
				StickInput_1.x = Input.GetAxis ("L_XAxis_" + PID);
				StickInput_1.y = Input.GetAxis ("L_YAxis_" + PID);
				if (StickInput_1.magnitude < deadzone) {
						StickInput_1 = Vector2.zero;
				} else {
						L_Stick_Time = Time.time;
						L_Stroke = StickInput_1;
				}
		
				// Right Analog Stick
				StickInput_2.x = Input.GetAxis ("R_XAxis_" + PID);
				StickInput_2.y = Input.GetAxis ("R_YAxis_" + PID);
				if (StickInput_2.magnitude < deadzone) {
						StickInput_2 = Vector2.zero;
				} else {
						R_Stick_Time = Time.time;
						R_Stroke = StickInput_2;
				}

				if (L_Stick_Time != 0 && R_Stick_Time != 0) {
						if (Math.Abs (L_Stick_Time - R_Stick_Time) <= 0.1) {
								Res_Stroke = L_Stroke + R_Stroke;
								currentCharacter.ChangeDirection (Res_Stroke.x, Res_Stroke.y);
								currentCharacter.Sequence = true;
								currentCharacter.Swim (1);
				
						} 
						L_Stick_Time = 0;
						R_Stick_Time = 0;
				} else {
						currentCharacter.Sequence = true;
						currentCharacter.ChangeDirection (L_Stroke.x, L_Stroke.y);
						currentCharacter.Swim (1);
						currentCharacter.ChangeDirection (R_Stroke.x, R_Stroke.y);
						currentCharacter.Swim (1);
				}

		}
		
		int 									PID;
		bool									L_Axis;
		bool									R_Axis;
		float 									L_Stick_Time;
		float 									R_Stick_Time;
		List<string>							AxisInUse = new List<string> ();
		Vector2 								StickInput_1;
		Vector2 								StickInput_2;
		Vector2									L_Stroke;
		Vector2 								R_Stroke;
		Vector2 								Res_Stroke;
		public float 							deadzone = 0.75f;
		public float							AxisThreshold = 0;
		public float							AxisMax = 0.9f;
		WaterCharacter 							currentCharacter;
}
