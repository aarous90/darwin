
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class WaterCharacter : ICharacter
{
	public WaterCharacter()
	{

	}

	public void Flip(float h)
	{
		if (h != 0)
		{
			transform.eulerAngles = (h > 0) ? Vector3.up * 90 : Vector3.up * -90;

		}
	}

	public void SetDirection(Vector2 SwimDir)
	{
		SwimDirection = SwimDir;
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


//		if (CanSwim())
//		{
		MaxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;
		SwimDirection.x = MoveSpeed * HorizontalForce;
		SwimDirection.y = MoveSpeed * VerticalForce;
		VerticalForce *= 1.0f - Drag;
		HorizontalForce *= 1.0f - Drag;
		SwimDirection *= 0.9f;
//			}

		Flip(SwimDirection.x);

		if (Math.Abs(SwimDirection.x) > MaxSpeed)
		{
			SwimDirection.x = Math.Sign(SwimDirection.x) * MaxSpeed;
		}
		if (Math.Abs(SwimDirection.y) > MaxSpeed)
		{
			SwimDirection.y = Math.Sign(SwimDirection.y) * MaxSpeed;
		}

		Controller.Move(SwimDirection * Time.deltaTime);
	}

////////////////////////////////////////////////////////////////////

#region ICharacter implementation

	public override CharacterType GetCharacterType()
	{
		return CharacterType.Water;
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
		HorizontalForce += 0.5f * MoveSpeed * Math.Sign(SwimDirection.x);
		VerticalForce += 0.5f * MoveSpeed * Math.Sign(SwimDirection.y) * -1;
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
// [HideInInspector]
	public bool								Sequence;

//  public float							Gravity = 20;
	public float 							MaxSpeed_1 = 5;
	public float 							MaxSpeed_2 = 10;
	public float 							MoveSpeed = 5;
	public float 							Drag = 0.1f;

////////////////////////////////////////////////////////////////////

	float									HorizontalForce;
	float									VerticalForce;
	Vector2 								SwimDirection;
	float 									MaxSpeed;
	_CharacterController                    Controller;
	Animator  								Anim;

}

