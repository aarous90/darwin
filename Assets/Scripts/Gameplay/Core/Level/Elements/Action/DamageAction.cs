
using UnityEngine;

public class DamageAction : AbstractAction
{
	public DamageAction()
	{
	}

	#region implemented abstract members of AbstractAction

	protected override void DoAction(UnityEngine.Component other)
	{
		if (other is IDamageable)
		{
			timer += Time.deltaTime;
			if (timer < Attack.Cooldown)
			{
				return;
			}
			timer = 0;

			IDamageable damageable = other as IDamageable;

			DamageContext damage = new DamageContext();
			damage.Attack = Attack;
			damage.Attacker = null;
			damage.Enemy = damageable;
			damage.IsMeele = true;

			damageable.OnDamaged(damage);

			if (Util.Length(Force) > 0 
			    && other.gameObject.rigidbody != null)
			{
				other.gameObject.rigidbody.AddForce(Force);
			}
		}
	}

	#endregion

	public AttackContext Attack;

	public bool RangedDamage;

	public bool MeleeDamage;

	public bool SpecialDamage;

	public Vector3 Force;

	float timer = 0;
}
