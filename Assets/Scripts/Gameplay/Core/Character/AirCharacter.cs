
using UnityEngine;

public class AirCharacter : ICharacter
{
	public AirCharacter()
	{
	}
	
	void Start()
	{
	}
	
	void Update()
	{
	}

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
		throw new System.NotImplementedException();
	}

	public override void OnDamaged()
	{
		throw new System.NotImplementedException();
	}

	public override void OnDeath()
	{
		throw new System.NotImplementedException();
	}

	public override void OnRegenerate()
	{
		throw new System.NotImplementedException();
	}

	public override void OnBoost()
	{
		throw new System.NotImplementedException();
	}

	#endregion
}

