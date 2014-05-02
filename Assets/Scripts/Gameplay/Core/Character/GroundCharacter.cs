
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class GroundCharacter : ICharacter
{
		public GroundCharacter ()
		{

		}

		public void Flip (float h)
		{
				transform.rotation = (h > 0) ? LookRight : LookLeft;
		}

		public void SetDirection (float x)
		{
				Direction = x;
		}

		void Start ()
		{
				//Initial Character rotation
				LookRight = transform.rotation;

				//Initial Character rotation flipped horizontally
				LookLeft = LookRight * Quaternion.Euler (0, 180, 0); 
		
		}

		void Update ()
		{

		}

		void FixedUpdate ()
		{		

		}

		////////////////////////////////////////////////////////////////////

	#region ICharacter implementation

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
				throw new NotImplementedException ();

		}

		public override void Move (float deltaTime)
		{
				throw new NotImplementedException ();
		}

		public override bool CanJump ()
		{
				throw new NotImplementedException ();
		}

		public override void Jump (float deltaTime)
		{
				throw new NotImplementedException ();
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

		public override void OnDamaged ()
		{
				throw new NotImplementedException ();
		}

		public override void OnDeath ()
		{
				throw new NotImplementedException ();
		}

		public override void OnRegenerate ()
		{
				throw new NotImplementedException ();
		}

		public override void OnBoost ()
		{
				throw new NotImplementedException ();
		}

	#endregion

		////////////////////////////////////////////////////////////////////

		public bool								Sequence;
		public float							Gravity = 9.81f;
		public float 							MaxSpeed_1 = 5;
		public float 							MaxSpeed_2 = 10;
		public float 							MoveForce = 100f;
		public float 							JumpForce = 500f;

		////////////////////////////////////////////////////////////////////

		Vector3 								RayOffset;
		Vector3 								Velocity;
		Quaternion								LookRight;
		Quaternion								LookLeft;
		float 									RayLength;
		float 									MaxSpeed;
		float 									Direction;

}

