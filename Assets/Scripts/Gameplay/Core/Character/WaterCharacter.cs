
using UnityEngine;
using System;

public class WaterCharacter : ICharacter
{
	public WaterCharacter()
	{
	}
	
	void Start()
	{
		//Initial Character rotation
		LookRight = transform.rotation;
		
		//Initial Character rotation flipped horizontally
		LookLeft = LookRight * Quaternion.Euler(0, 180, 0);
	}
	
	void Update()
	{
	}
	
	void FixedUpdate()
	{
		
		//Check for Input Sequence adjust Maxspeed
		MaxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;
		
		rigidbody.AddForce(Vector3.right * HorizontalForce * MovementSpeed);
		rigidbody.AddForce(Vector3.up * VerticalForce * MovementSpeed);
		
		//MovementForce Drag
		VerticalForce *= 1.0f - Drag;
		HorizontalForce *= 1.0f - Drag;
		
		//Velocity Drag
		Velocity = rigidbody.velocity;
		Velocity.x *= 0.9f;
		Velocity.y *= 0.9f;
		rigidbody.velocity = Velocity;
		
		// set velocity to MaxSpeed if exceeding
		if (Mathf.Abs(rigidbody.velocity.x) > MaxSpeed)
		{
			Velocity = rigidbody.velocity;
			Velocity.x = Mathf.Sign(rigidbody.velocity.x) * MaxSpeed;
			rigidbody.velocity = Velocity;
		}
		if (Mathf.Abs(rigidbody.velocity.y) > MaxSpeed)
		{
			Velocity = rigidbody.velocity;
			Velocity.y = Mathf.Sign(rigidbody.velocity.y) * MaxSpeed;
			rigidbody.velocity = Velocity;
		}
		
	}
	
	public void Flip(float x)
	{
		transform.rotation = (x > 0) ? LookRight : LookLeft;
	}
	
	public void SetDirection(float x, float y)
	{
		X_Direction = x;
		Y_Direction = y;
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
		throw new System.NotImplementedException();
	}
	
	public override void Move(float deltaTime)
	{	
		throw new System.NotImplementedException();
	}
	
	public override bool CanJump()
	{
		throw new System.NotImplementedException();
	}
	
	public override void Jump(float deltaTime)
	{
		throw new System.NotImplementedException();
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
		Flip(X_Direction);
		HorizontalForce += 0.5f * MovementSpeed * Math.Sign(X_Direction);
		VerticalForce += 0.5f * MovementSpeed * Math.Sign(Y_Direction) * -1;
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
	

	////////////////////////////////////////////////////////////////////

	float									MaxSpeed;
	float									HorizontalForce;
	float									VerticalForce;
	float 									X_Direction;
	float 									Y_Direction;
	Quaternion								LookRight;
	Quaternion								LookLeft;
	Vector3 								Velocity;
	public bool								Sequence;
	public float 							Drag = 0.3f;
	public float							MovementSpeed = 10;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
}

