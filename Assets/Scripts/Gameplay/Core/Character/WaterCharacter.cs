
using UnityEngine;

public class WaterCharacter : ICharacter
{
	public WaterCharacter()
	{
	}
	
	void Start()
	{
	}
	
	void Update()
	{
	}

	#region ICharacter implementation

	public override float GetLive()
	{
		throw new System.NotImplementedException();
	}
	
	public override void Regenerate(float value)
	{
		throw new System.NotImplementedException();
	}
	
	public override void TakeDamage(float value)
	{
		throw new System.NotImplementedException();
	}
	
	public override float GetBoost()
	{
		throw new System.NotImplementedException();
	}
	
	public override void GainBoost(float value)
	{
		throw new System.NotImplementedException();
	}
	
	public override void UseBoost(float value)
	{
		throw new System.NotImplementedException();
	}
	
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
	
	#endregion
}

