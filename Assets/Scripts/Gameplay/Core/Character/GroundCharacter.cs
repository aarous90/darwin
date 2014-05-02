
using UnityEngine;
using System;

public class GroundCharacter : ICharacter
{
	public GroundCharacter()
	{

	}

	public void Flip(float h)
	{
		transform.rotation = (h > 0) ? LookRight : LookLeft;
	}

	public void SetDirection(float x)
	{
		Direction = x;
	}

	void Start()
	{
		//Initial Character rotation
		LookRight = transform.rotation;

		//Initial Character rotation flipped horizontally
		LookLeft = LookRight * Quaternion.Euler(0, 180, 0); 

		//Length of Raycast to check ground considering collider offset
		RayLength = collider.bounds.size.y / 2 - 
			Math.Abs(transform.position.y - collider.bounds.center.y);

		//Offset value for additional Raycasts considering collider offset
		RayOffset = Vector3.right * (collider.bounds.size.x / 2 - 
			Math.Abs(transform.position.x - collider.bounds.center.x));
				

	}

	void Update()
	{

	}

	void FixedUpdate()
	{		
		//Check for Input Sequence adjust Maxspeed
		MaxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;

		//If Character is exceeding Maxspeed set velocity to Maxspeed
		if (Mathf.Abs(rigidbody.velocity.x) > MaxSpeed)
		{
			Velocity = rigidbody.velocity;
			Velocity.x = Mathf.Sign(rigidbody.velocity.x) * MaxSpeed;
			rigidbody.velocity = Velocity;
		}
				
		//TODO Adjust position while fallling?
		if (!CanJump())
		{
			rigidbody.AddForce(Vector2.right * Direction * 2);
		}

		//Apply Gravity
		rigidbody.AddForce(-Vector3.up * Gravity);

	}

	////////////////////////////////////////////////////////////////////

	#region ICharacter implementation

	public override bool UseSpecial(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public override bool UseMelee(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public override bool UseRanged(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public override void DoMeleeDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public override void DoRangedDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public override void DoSpecialDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public override bool CanMove()
	{
		if (Physics.Raycast(transform.position, -transform.up, RayLength) || 
			Physics.Raycast(transform.position + RayOffset, -transform.up, RayLength) ||
			Physics.Raycast(transform.position - RayOffset, -transform.up, RayLength))
		{
			return true;
		}
		else
		{
			return false;
		}

	}

	public override void Move(float deltaTime)
	{
		if (Direction * rigidbody.velocity.x < MaxSpeed)
		{
			rigidbody.AddForce(Vector2.right * Direction * MoveForce);
		}
	}

	public override bool CanJump()
	{
		if (Physics.Raycast(transform.position, -transform.up, RayLength) || 
			Physics.Raycast(transform.position + RayOffset, -transform.up, RayLength) ||
			Physics.Raycast(transform.position - RayOffset, -transform.up, RayLength))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Jump(float deltaTime)
	{
	
		if (Math.Abs(Direction) > 0.3)
		{
			if (Mathf.Abs(rigidbody.velocity.x) > MaxSpeed * 0.75f)
			{
				//TODO add horizontal force
				Velocity = Vector3.zero;
				rigidbody.velocity = Velocity;

				rigidbody.AddForce(new Vector2(15, JumpForce));
			}
			else
			{
				//TODO add horizontal force
				Velocity = Vector3.zero;
				rigidbody.velocity = Velocity;

				rigidbody.AddForce(new Vector2(10, JumpForce));
							
			}	
		}
		else
		{
			rigidbody.AddForce(Vector2.up * JumpForce);
		}
	}

	public override bool CanFly()
	{
		throw new System.NotImplementedException();
	}

	public override void Fly(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	public override bool CanSwim()
	{
		throw new System.NotImplementedException();
	}

	public override void Swim(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	public override void OnDamaged()
	{
		throw new NotImplementedException();
	}

	public override void OnDeath()
	{
		throw new NotImplementedException();
	}

	public override void OnRegenerate()
	{
		throw new NotImplementedException();
	}

	public override void OnBoost()
	{
		throw new NotImplementedException();
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

