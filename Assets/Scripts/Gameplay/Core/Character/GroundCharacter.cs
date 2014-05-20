
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class GroundCharacter : ICharacter
{
	public GroundCharacter()
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
	
		if (CanMove())
		{
			MaxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;
			CurrentSpeed = 0;
			MoveDirection.y = 0;
			MoveDirection.x = MoveSpeed * MoveForce;
			MoveForce *= 1.0f - Drag;

			if (Jumping)
			{
				Jumping = false;
				Anim.SetTrigger("Jump");
				MoveDirection.y = JumpSpeed;
			}

			CurrentSpeed = MoveDirection.x;
		}
		else
		{
			MoveForce = 0;

			if (CurrentSpeed != 0 && Math.Abs(CurrentSpeed) > MaxSpeed * 0.3f)
			{
				if (CurrentSpeed >= 0 && Direction >= 0 || CurrentSpeed < 0 && Direction < 0)
				{			

				}
				else
				{
					CurrentSpeed = 0;
					MoveDirection.x = 0;
				}
			}
			else
			{
				MoveDirection.x = MoveSpeed * Direction;
			}
		}



		Flip(Direction);

		if (Math.Abs(MoveDirection.x) > 0.1 && CanMove())
		{
			Anim.SetBool("Walk", true);
		}
		else
		{
			Anim.SetBool("Walk", false);
		}


		if (Math.Abs(MoveDirection.x) > MaxSpeed)
		{
			MoveDirection.x = Math.Sign(MoveDirection.x) * MaxSpeed;
		}

		MoveDirection.y -= Gravity * Time.deltaTime;
		Controller.Move(MoveDirection * Time.deltaTime);
	}

////////////////////////////////////////////////////////////////////

#region ICharacter implementation
	
	public override CharacterType GetCharacterType()
	{
		return CharacterType.Ground;
	}

	public override bool UseSpecial(SpecialAttackContext context)
	{
		throw new System.NotImplementedException();
	}
	
	public override bool UseMelee(MeleeAttackContext context)
	{
		throw new System.NotImplementedException();
	}
	
	public override bool UseRanged(RangedAttackContext context)
	{
		throw new System.NotImplementedException();
	}
	
	public override void DoMeleeDamage(DamageContext context)
	{
		base.DoMeleeDamage(context);
	}
	
	public override void DoRangedDamage(DamageContext context)
	{
		base.DoRangedDamage(context);
	}
	
	public override void DoSpecialDamage(DamageContext context)
	{
		base.DoSpecialDamage(context);
	}

	public override bool CanMove()
	{
		if (Controller.Grounded)
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
		if (CanMove())
		{
			MoveForce += 0.5f * MoveSpeed * Math.Sign(Direction);
		}
	}

	public override bool CanJump()
	{
		if (Controller.Grounded)
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
		if (CanJump())
		{
			Jumping = true;
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
	
	public override void OnDamaged(DamageContext damage)
	{
		base.OnDamaged(damage);
	}
	
	public override void OnDeath()
	{
		base.OnDeath();
	}
	
	public override void OnRegenerate()
	{
		base.OnRegenerate();
	}
	
	public override void OnBoost()
	{
		base.OnBoost();
	}
	
	public override void OnDecay()
	{
		base.OnDecay();
	}
	
	public override void OnSpawned()
	{
		base.OnSpawned();
	}

#endregion

////////////////////////////////////////////////////////////////////
	//[HideInInspector]
	public bool								Sequence;

	public float							Gravity = 20;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
	public float 							MoveSpeed = 5;
	public float 							JumpSpeed = 15;
	public float 							Drag = 0.1f;

////////////////////////////////////////////////////////////////////

	Vector2 								MoveDirection;
	float 									MoveForce;
	float 									MaxSpeed;
	float 									CurrentSpeed;
	float 									Direction;
	bool									Jumping;
	_CharacterController                    Controller;
	Animator  								Anim;

}

