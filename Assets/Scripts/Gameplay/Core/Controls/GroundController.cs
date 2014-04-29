using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : IController
{
		public GroundController (int joystickID)
		{
				PID = joystickID;
		}

#region IController implementation

		public override void Initialize (ICharacter character)
		{
				if (character is GroundCharacter) {
						currentCharacter = character as GroundCharacter;
				} else {
						throw new ArgumentException ("Invalid character type!");
				}
		}

#endregion

//Use this for initialization
		public override void Start ()
		{

		}			

//Update is called once per frame
		public override void Update ()
		{


		}

		public override void FixedUpdate ()
		{		
				
				currentCharacter.SetDirection(Input.GetAxis ("L_XAxis_" + PID));
				
				//Check horizontal input, flip character accordingly
				if (Math.Abs (Input.GetAxis ("L_XAxis_" + PID)) > AxisThreshold) {
						currentCharacter.Flip (Input.GetAxis ("L_XAxis_" + PID));
				}
				
				//Add left Trigger to AxisInUse when value exceeds AxisMax and store time 
				if (Input.GetAxis ("L_Trigger_" + PID) > AxisMax && !AxisInUse.Contains ("L_Trigger_" + PID)) {
						AxisInUse.Add ("L_Trigger_" + PID);
						L_Trigger_Time = Time.time;
				}
				
				//Add right Trigger to AxisInUse when value exceeds AxisMax and store time
				if (Input.GetAxis ("R_Trigger_" + PID) > AxisMax && !AxisInUse.Contains ("R_Trigger_" + PID)) {
						AxisInUse.Add ("R_Trigger_" + PID);
						R_Trigger_Time = Time.time;
				}	
				
				//Jump if AxisInUse contains both Triggers and the time difference is below 0.05 
				if (AxisInUse.Contains ("R_Trigger_" + PID) && AxisInUse.Contains ("L_Trigger_" + PID)) {
						if (Math.Abs (L_Trigger_Time - R_Trigger_Time) <= 0.05) {
								if (currentCharacter.CanJump ()) {
										currentCharacter.Jump (1);
								}
						}
				}
				
				//Remove left Trigger from AxisInUse when value deceeds AxisMax, check for input sequence and call move
				if (Input.GetAxis ("L_Trigger_" + PID) < AxisMax && AxisInUse.Contains ("L_Trigger_" + PID)) {
						L_Trigger = true;	
						if (R_Trigger) {
								currentCharacter.Sequence = true;
								if (currentCharacter.CanMove ()) {
										currentCharacter.Move (1);
								}
								R_Trigger = false;
						} else {
								currentCharacter.Sequence = false;
								if (currentCharacter.CanMove ()) {
										currentCharacter.Move (1);
								}
						}
						AxisInUse.Remove ("L_Trigger_" + PID);
						L_Trigger_Time = Time.time;
				}
				
				//Remove right Trigger from AxisInUse when value deceeds AxisMax, check for input sequence and call move
				if (Input.GetAxis ("R_Trigger_" + PID) < AxisMax && AxisInUse.Contains ("R_Trigger_" + PID)) {
						R_Trigger = true;	
						if (L_Trigger) {
								if (currentCharacter.CanMove ()) {
										currentCharacter.Move (1);
								}
								currentCharacter.Sequence = true;
								L_Trigger = false;
						} else {
								currentCharacter.Sequence = false;
								if (currentCharacter.CanMove ()) {
										currentCharacter.Move (1);
								}
						}
						AxisInUse.Remove ("R_Trigger_" + PID);
						R_Trigger_Time = Time.time;
				}

		}

		List<string>							AxisInUse = new List<string> ();
		bool    								R_Trigger;
		bool 									L_Trigger;
		float    								R_Trigger_Time;
		float 									L_Trigger_Time;
		int 									PID;
		public float							AxisThreshold = 0.3f;
		public float							AxisMax = 0.9f;
		GroundCharacter 						currentCharacter;
}
