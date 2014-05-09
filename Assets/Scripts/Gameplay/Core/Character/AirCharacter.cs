
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class AirCharacter : ICharacter
{
	public AirCharacter()
	{

	}

	public void Flip(float h)
	{
		if (Direction != 0)
		{
			transform.eulerAngles = (h > 0) ? Vector3.up * 90 : Vector3.up * -90;

		}
	}

	public void SetDirection(float x)
	{
		Direction = x;
	}

	void Start()
	{
		Controller = GetComponent<_CharacterController>();
		Anim = GetComponent<Animator>();
	}

	void Update()
	{

	}

	void FixedUpdate()
	{	
		FlyDirection.x = Direction * HorizontalSpeed;

		if (Swinging)
		{
			if (Sequence)
			{
				FlyDirection.y = VerticalSpeed;
			}
			else
			{
				FlyDirection.y = VerticalSpeed / 2;
			}
			Swinging = false;
		}

		if (Math.Abs(FlyDirection.x) > MaxSpeed)
		{
			FlyDirection.x = Math.Sign(FlyDirection.x) * MaxSpeed;
		}

		Flip(Direction);
		FlyDirection.y -= Gravity * Time.deltaTime;
		Controller.Move(FlyDirection * Time.deltaTime);
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
		Swinging = true;
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
	[HideInInspector]
	public bool								Sequence;

	public float							Gravity = 20;
	public float 							MaxSpeed = 10;
	public float 							HorizontalSpeed = 5;
	public float 							VerticalSpeed = 15;
	public float 							Drag = 0.1f;

////////////////////////////////////////////////////////////////////

	Vector2 								FlyDirection;
	float 									Direction;
	bool									Swinging;
	_CharacterController                    Controller;
	Animator  								Anim;

}

