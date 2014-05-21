
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class AirCharacter : ICharacter, IAirAnimations
{
	public AirCharacter()
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

	void OnDeathEnded ()
	{
		OnDecay ();
		anim.SetBool ("Death", false);
	}

	void FixedUpdate()
	{	
		flyDirection.x = direction * HorizontalSpeed;

		if (swinging)
		{
			if (Sequence)
			{
				flyDirection.y = VerticalSpeed;
			}
			else
			{
				flyDirection.y = VerticalSpeed / 2;
			}
			swinging = false;
		}

		if (Math.Abs(flyDirection.x) > MaxSpeed)
		{
			flyDirection.x = Math.Sign(flyDirection.x) * MaxSpeed;
		}

		Flip(direction);
		flyDirection.y -= Gravity * Time.deltaTime;
		controller.Move(flyDirection * Time.deltaTime);
	}

	////////////////////////////////////////////////////////////////////

	#region IAirAnimations implementation

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
		return CharacterType.Air;
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
		swinging = true;
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
		anim.SetBool ("Death", true);
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
	public float 							MaxSpeed = 10;
	public float 							HorizontalSpeed = 5;
	public float 							VerticalSpeed = 15;
	public float 							Drag = 0.1f;

	////////////////////////////////////////////////////////////////////

	Vector2 								flyDirection;
	float 									direction;
	bool									swinging;
	_CharacterController                    controller;
	Animator  								anim;

}

