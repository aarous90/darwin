
public interface IFightable : IDamageable
{
	void DoMeleeDamage(DamageContext context);
	
	void DoRangedDamage(DamageContext context);
	
	void DoSpecialDamage(DamageContext context);
}

