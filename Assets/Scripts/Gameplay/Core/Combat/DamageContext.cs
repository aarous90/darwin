

using UnityEngine;

public struct DamageContext
{
	public IFightable Attacker;
	public IDamageable Enemy;
	public AttackContext Attack;
	public bool IsMeele;
	public bool IsRanged;
	public bool IsSpecial;

	/// <summary>
	/// Rolls the damage based on the AttackContext.
	/// Damage is calculated like this:
	/// 
	/// 	BaseDamage + DiceCount * DiceRoll;
	/// 
	/// </summary>
	/// <returns>The damage.</returns>
	public float RollDamage()
	{
		if (Attack == null)
		{
			Debug.Log("No attack found for the damage context!");
			return 0;
		}
		float randomDamage = 0;
		for (int i = 0; i < Attack.DiceCount; i++)
		{
			randomDamage += Util.Randomizer.Next(Attack.DiceSides);
		}

		Debug.Log(Attacker + " did attack (" + Attack.DiceCount + "d" + Attack.DiceSides + " + " + Attack.BaseDamage 
		          + ") to " + Enemy + " with " + (Attack.BaseDamage + randomDamage) + " damage!");

		return Attack.BaseDamage + randomDamage;
	}
}

