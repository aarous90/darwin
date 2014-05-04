
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

				Controller = GetComponent<_CharacterController> ();
				Anim = GetComponent<Animator> ();
		
		}

		void Update ()
		{

		}

		void FixedUpdate ()
		{		
				if (CanMove ()) {
						MoveDirection.x = MoveSpeed * MoveForce;
						MoveForce *= 1.0f - Drag;
				}

				MoveDirection.y -= Gravity * Time.deltaTime;

				if (Math.Abs (MoveDirection.x) > 0.1) {
						Anim.SetBool ("Walk", true);
				} else {
						Anim.SetBool ("Walk", false);
				}

				Controller.Move (MoveDirection * Time.deltaTime);
				//Debug.Log (MoveDirection);
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
				if (Controller.grounded) {
						return true;
				} else {
						return false;
				}

		}

		public override void Move (float deltaTime)
		{		
				if (CanMove ()) {
						MoveForce += 0.5f * MoveSpeed * Math.Sign (Direction);
				}
		}

		public override bool CanJump ()
		{
				if (Controller.grounded) {
						return true;
				} else {
						return false;
				}
		}

		public override void Jump (float deltaTime)
		{
				Anim.SetTrigger ("Jump");
				MoveDirection.y = JumpSpeed;
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
		public float							Gravity = 20;
		public float 							MaxSpeed_1 = 5;
		public float 							MaxSpeed_2 = 10;
		public float 							MoveSpeed = 5;
		public float 							JumpSpeed = 15;
		public float 							Drag = 0.1f;

		////////////////////////////////////////////////////////////////////

		Vector3 								RayOffset;
		Vector3 								Velocity;
		Vector2 								MoveDirection;
		Quaternion								LookRight;
		Quaternion								LookLeft;
		float 									MoveForce;
		float 									RayLength;
		float 									MaxSpeed;
		float 									Direction;
		_CharacterController                    Controller;
		Animator  								Anim;

}

