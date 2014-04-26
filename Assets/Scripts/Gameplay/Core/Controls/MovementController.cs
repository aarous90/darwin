using UnityEngine;

/// <summary>
/// The Movement controller manages to switch between different input settings for each terrain (Air, Ground, Water).
/// </summary>
using System;


public class MovementController
{

		public MovementController (string joystickName, int joystickID)
		{
				this.joystickID = joystickID;
				this.joystickName = joystickName;
		}

		// Use this for initialization
		void Start ()
		{
		// TODO: remove this, character will do all stuff
		}

		// Update is called once per frame
		void Update ()
		{
		// TODO: remove this, character will do all stuff
		}

		public void FixedUpdate ()
		{
		// TODO: remove this, character will do all stuff

				// Switch on control type
				switch (currentMovementType) {
				case MovementType.Air:
						{
								airController.FixedUpdate ();
						}
						break;
				case MovementType.Ground:
						{
								groundController.FixedUpdate ();
						}
						break;
				case MovementType.Water:
						{
								waterController.FixedUpdate ();
						}
						break;
				case MovementType.Invalid:
						{
						}
						break;
				default:
						{
								throw new UnityException ("Invalid control type!");
						}
				}
		}

////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Take control of a certain character. Automaticly switches the input layout!
		/// </summary>
		public void UseCharacter (ICharacter character)
		{
				// TODO: free old character
				currentCharacter = character;

				if (currentCharacter is AirCharacter) {
						currentMovementType = MovementType.Air;
						airController.Initialize (character);
						airController.Start (); // TODO: remove start call after moving init to character
				} else if (currentCharacter is GroundCharacter) {
						currentMovementType = MovementType.Ground;
						groundController.Initialize (character);
						groundController.Start (); // TODO: remove start call after moving init to character
				} else if (currentCharacter is WaterCharacter) {
						currentMovementType = MovementType.Water;
						waterController.Initialize (character);
						waterController.Start (); // TODO: remove start call after moving init to character
				} else {
						currentMovementType = MovementType.Invalid;
						throw new UnityException ("Invalid control type!");
				}
		}

		public ICharacter CurrentCharacter {
				get {
						if (currentCharacter == null) {
								//print("WARNING: Tried to fetch the controllers character while no character is controlled!");
								return null;
						}
						return currentCharacter;
				}
		}

		public MovementType CurrentControlType {
				get {
						return currentMovementType;
				}
		}

		public string JoystickName {
				get {
						return joystickName;
				}
		}

		public int JoystickID {
				get {
						return joystickID;
				}
		}

////////////////////////////////////////////////////////////////////

		string joystickName;
		int joystickID;

		/// <summary>
		/// The type of the current control.
		/// </summary>
		MovementType currentMovementType = MovementType.Invalid;

		/// <summary>
		/// The current used character.
		/// </summary>
		ICharacter currentCharacter = null;

		/// <summary>
		/// The air controller.
		/// </summary>
		AirController airController = new AirController ();

		/// <summary>
		/// The ground controller.
		/// </summary>
		GroundController groundController = new GroundController (joystickID);

		/// <summary>
		/// The water controller.
		/// </summary>
		WaterController waterController = new WaterController (joystickID);

}
