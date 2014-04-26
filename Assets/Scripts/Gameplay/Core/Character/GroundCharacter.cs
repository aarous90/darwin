
using UnityEngine;
using System;

public class GroundCharacter : ICharacter
{
		public GroundCharacter ()
		{

		}

		public void Flip (float h)
		{
				transform.rotation = (h > 0) ? LookRight : LookLeft;
				Direction = h;
		}

		void Start ()
		{
				//Initial Character rotation
				LookRight = transform.rotation;

				//Initial Character rotation flipped horizontally
				LookLeft = LookRight * Quaternion.Euler (0, 180, 0); 

				//Length of Raycast to check ground considering collider offset
				RayLength = collider.bounds.size.y / 2 - 
						Math.Abs (transform.position.y - collider.bounds.center.y);

				//Offset value for additional Raycasts considering collider offset
				RayOffset = Vector3.right * (collider.bounds.size.x / 2 - 
						Math.Abs (transform.position.x - collider.bounds.center.x));
		}

		void Update ()
		{

		}

		void FixedUpdate ()
		{		
				//Check for Input Sequence adjust Maxspeed
				MaxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;

				//If Character is grounded apply Movementforce and Drag
				if (CanMove ()) {
						rigidbody.AddForce (Vector3.right * MovementForce * MovementSpeed);
						MovementForce *= 1.0f - Drag;

				}

				//If Character is exceeding Maxspeed set velocity to Maxspeed
				if (Mathf.Abs (rigidbody.velocity.x) > MaxSpeed) {
						Velocity = rigidbody.velocity;
						Velocity.x = Mathf.Sign (rigidbody.velocity.x) * MaxSpeed;
						rigidbody.velocity = Velocity;
				}

				//Apply Gravity
				rigidbody.AddForce (-Vector3.up * Gravity * rigidbody.mass);

		}


#region ICharacter implementation

		public override float GetLive ()
		{
				throw new System.NotImplementedException ();
		}

		public override void Regenerate (float value)
		{
				throw new System.NotImplementedException ();
		}

		public override void TakeDamage (float value)
		{
				throw new System.NotImplementedException ();
		}

		public override float GetBoost ()
		{
				throw new System.NotImplementedException ();
		}

		public override void GainBoost (float value)
		{
				throw new System.NotImplementedException ();
		}

		public override void UseBoost (float value)
		{
				throw new System.NotImplementedException ();
		}

		public override bool UseSpecial (AttackContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override bool UseMelee (AttackContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override bool UseRanged (AttackContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override void DoMeleeDamage (DamageContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override void DoRangedDamage (DamageContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override void DoSpecialDamage (DamageContext context)
		{
				throw new System.NotImplementedException ();
		}

		public override bool CanMove ()
		{
				if (Physics.Raycast (transform.position, -transform.up, RayLength) || 
						Physics.Raycast (transform.position + RayOffset, -transform.up, RayLength) ||
						Physics.Raycast (transform.position - RayOffset, -transform.up, RayLength)) {
						return true;
				} else {
						return false;
				}

		}

		public override void Move (float deltaTime)
		{
				MovementForce += 0.5f * MovementSpeed * Math.Sign (Direction);
		}

		public override bool CanJump ()
		{
				if (Physics.Raycast (transform.position, -transform.up, RayLength) || 
						Physics.Raycast (transform.position + RayOffset, -transform.up, RayLength) ||
						Physics.Raycast (transform.position - RayOffset, -transform.up, RayLength)) {
						return true;
				} else {
						return false;
				}
		}

		public override void Jump (float deltaTime)
		{
				rigidbody.velocity = rigidbody.velocity + (Vector3.up * JumpSpeed);
		}

		public override bool CanFly ()
		{
				throw new System.NotImplementedException ();
		}

		public override void Fly (float deltaTime)
		{
				throw new System.NotImplementedException ();
		}

		public override bool CanSwim ()
		{
				throw new System.NotImplementedException ();
		}

		public override void Swim (float deltaTime)
		{
				throw new System.NotImplementedException ();
		}

#endregion

		bool 									Grounded;
		Vector3 								RayOffset;
		Vector3 								Velocity;
		Quaternion								LookRight;
		Quaternion								LookLeft;
		float 									RayLength;
		float 									MovementForce;
		float 									MaxSpeed;
		float 									Direction;
		public bool								Sequence;
		public float 							Drag = 0.3f;
		public float							Gravity = 9.81f;
		public float 							MaxSpeed_1 = 5;
		public float 							MaxSpeed_2 = 10;
		public float							MovementSpeed = 10;
		public float							JumpSpeed = 10;

}

