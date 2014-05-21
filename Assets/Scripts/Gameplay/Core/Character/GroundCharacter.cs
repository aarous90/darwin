
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class GroundCharacter : ICharacter, IGroundAnimations
{
	public GroundCharacter()
	{

	}

	public void Flip(float h)
	{
		if (direction != 0)
		{
			transform.eulerAngles = (h > 0) ? Vector3.up * 90 : Vector3.up * -90;

		}
	}

	public void SetDirection(float x)
	{
		direction = x;
	}

	void Start()
	{
		controller = GetComponent<_CharacterController>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{

	}

	void FixedUpdate()
	{	

		if (controller.SideCollision)
		{
			moveForce = 0;
			moveDirection.x = 0;
		}

		if (CanMove())
		{
		
			if (Mathf.Abs(moveForce) < 0.1)
			{
				moveForce = 0;
			}

			maxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;

			currentSpeed = 0;
			moveDirection.y = 0;
			moveDirection.x = MoveSpeed * moveForce;
			moveForce *= 1.0f - Drag;

			currentSpeed = moveDirection.x;

			if (jumping)
			{
				jumping = false;
				anim.SetTrigger("Jump");
				moveDirection.y = JumpSpeed;
			}

						
		} else
		{
			moveForce = 0;

			if (currentSpeed != 0 && Math.Abs(currentSpeed) > maxSpeed * 0.75f)
			{
				if (currentSpeed > 0 && direction >= 0 || currentSpeed < 0 && direction <= 0)
				{			
								
				} else
				{
					currentSpeed = 0;
					moveDirection.x = 0;
				}
			} else
			{
				moveDirection.x = MoveSpeed * direction;
			}
		}



		Flip(direction);

		if (Math.Abs(moveDirection.x) > 0.1 && CanMove())
		{
			anim.speed = 1 + (Math.Abs(moveDirection.x) * 0.1f);
			anim.SetBool("Walk", true);
		} else
		{
			anim.SetBool("Walk", false);
		}


		if (Math.Abs(moveDirection.x) > maxSpeed)
		{
			moveDirection.x = Math.Sign(moveDirection.x) * maxSpeed;
		}

		moveDirection.y -= Gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	////////////////////////////////////////////////////////////////////

	#region IGroundAnimations implementation

	public void OnIdleBegin()
	{
	}

	public void OnIdleEnd()
	{

	}

	public void OnBoringBegin()
	{

	}

	public void OnBoringEnd()
	{

	}

	public void OnWalkBegin()
	{

	}

	public void OnWalkEnd()
	{

	}

	public void OnJumpBegin()
	{

	}

	public void OnJumpEnd()
	{

	}

	public void OnHitBegin()
	{

	}

	public void OnHitEnd()
	{
		anim.SetBool("Hit", false);
	}

	public void OnDeathBegin()
	{

	}
	
	public void OnDeathEnd()
	{
		OnDecay();
		anim.SetBool("Death", false);
    }

	#endregion

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
		if (controller.Grounded)
		{
			return true;
		} else
		{
			return false;
		}

	}

	public override void Move(float deltaTime)
	{		
		if (CanMove())
		{
			moveForce += 1.5f * Math.Sign(direction);
		}
	}

	public override bool CanJump()
	{
		if (controller.Grounded)
		{
			return true;
		} else
		{
			return false;
		}
	}

	public override void Jump(float deltaTime)
	{
		if (CanJump())
		{
			jumping = true;
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
		anim.SetBool("Hit", true);

		base.OnDamaged(damage);
	}
	
	public override void OnDeath()
	{
		anim.SetBool("Death", true);

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

	[HideInInspector]
	public bool								Sequence;
	public float							Gravity = 20;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
	public float 							MoveSpeed = 5;
	public float 							JumpSpeed = 15;
	public float 							Drag = 0.1f;

////////////////////////////////////////////////////////////////////

	Vector2 								moveDirection;
	float 									moveForce;
	float 									maxSpeed;
	float 									currentSpeed;
	float 									direction;
	bool									jumping;
	_CharacterController                    controller;
	Animator  								anim;

}

