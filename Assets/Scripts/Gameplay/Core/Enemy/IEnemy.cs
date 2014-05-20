
public abstract class IEnemy : IFightable
{
	#region IDamageable implementation

	public void OnDamaged(DamageContext damage)
	{
		throw new System.NotImplementedException();
	}

	public void OnDeath()
	{
		throw new System.NotImplementedException();
	}

	public void OnDecay()
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

	#endregion


}
