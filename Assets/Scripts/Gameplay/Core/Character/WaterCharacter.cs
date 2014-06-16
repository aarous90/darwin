
using UnityEngine;
using System;

[RequireComponent (typeof(_CharacterController))]
public class WaterCharacter : ICharacter, IWaterAnimations
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
		swimDirection = SwimDir;
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
		if (IsDead) return;

//		if (CanSwim())
//		{
		maxSpeed = (Sequence) ? MaxSpeed_2 : MaxSpeed_1;
		swimDirection.x = MoveSpeed * horizontalForce;
		swimDirection.y = MoveSpeed * verticalForce;
		verticalForce *= 1.0f - Drag;
		horizontalForce *= 1.0f - Drag;
		swimDirection *= 0.9f;
//			}

		Flip(swimDirection.x);

		if (Math.Abs(swimDirection.x) > maxSpeed)
		{
			swimDirection.x = Math.Sign(swimDirection.x) * maxSpeed;
		}
		if (Math.Abs(swimDirection.y) > maxSpeed)
		{
			swimDirection.y = Math.Sign(swimDirection.y) * maxSpeed;
		}

		controller.Move(swimDirection * Time.deltaTime);
	}

	////////////////////////////////////////////////////////////////////

	#region IWaterAnimations implementation

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
		anim.SetBool("Hit", false);
	}

	public void OnDeathEnd()
	{
		OnDecay();
		anim.SetBool("Death", false);
	}

	#endregion

	////////////////////////////////////////////////////////////////////

	#region ICharacter implementation
	
	public override CharacterType CharacterType
	{
		get
		{
			return CharacterType.Water;
		}
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
		horizontalForce += 0.5f * MoveSpeed * Math.Sign(swimDirection.x);
		verticalForce += 0.5f * MoveSpeed * Math.Sign(swimDirection.y) * -1;
	}

	public override void OnDamaged(DamageContext damage)
	{
		if (IsDead) return;

		anim.SetBool("Hit", true);
		base.OnDamaged(damage);
	}

	public override void OnDeath()
	{
		if (IsDead) return;

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
		anim.SetBool("Death", false);
		anim.SetBool("Hit", false);
		base.OnDecay();
	}
	
	public override void OnSpawned(CharacterSpawn spawner)
	{
		base.OnSpawned(spawner);
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

	float									horizontalForce;
	float									verticalForce;
	Vector2 								swimDirection;
	float 									maxSpeed;
	_CharacterController                    controller;
	Animator  								anim;

}

