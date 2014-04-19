
using UnityEngine;

public class GroundCharacter : MonoBehaviour, ICharacter
{
	public GroundCharacter()
	{

	}

	void Start()
	{
	}

	void Update()
	{
	}

	#region ICharacter implementation

	public Player GetOwningPlayer()
	{
		throw new System.NotImplementedException();
	}
	
	public void Spawn()
	{
		
	}

	public float GetLive()
	{
		throw new System.NotImplementedException();
	}

	public void Regenerate(float value)
	{
		throw new System.NotImplementedException();
	}

	public void TakeDamage(float value)
	{
		throw new System.NotImplementedException();
	}

	public float GetBoost()
	{
		throw new System.NotImplementedException();
	}

	public void GainBoost(float value)
	{
		throw new System.NotImplementedException();
	}

	public void UseBoost(float value)
	{
		throw new System.NotImplementedException();
	}

	public bool UseSpecial(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public bool UseMelee(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public bool UseRanged(AttackContext context)
	{
		throw new System.NotImplementedException();
	}

	public void DoMeleeDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public void DoRangedDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public void DoSpecialDamage(DamageContext context)
	{
		throw new System.NotImplementedException();
	}

	public bool CanMove()
	{
		throw new System.NotImplementedException();
	}

	public void Move(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	public bool CanJump()
	{
		throw new System.NotImplementedException();
	}

	public void Jump(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	public bool CanFly()
	{
		throw new System.NotImplementedException();
	}

	public void Fly(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	public bool CanSwim()
	{
		throw new System.NotImplementedException();
	}

	public void Swim(float deltaTime)
	{
		throw new System.NotImplementedException();
	}

	#endregion
}

