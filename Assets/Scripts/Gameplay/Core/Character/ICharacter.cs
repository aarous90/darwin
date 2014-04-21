
using UnityEngine;

public abstract class ICharacter : MonoBehaviour
{

	public Player GetOwningPlayer()
	{
		return Owner;
	}

	////////////////////////////////////////////////////////////////////

	public void Spawn(CharacterSpawn spawner)
	{
		IsSpawned = true;
		CharacterManager.Get().RegisterCharacter(this);
		Object.Instantiate(this, spawner.transform.position, spawner.transform.rotation);
		Owner = PlayerManager.Get().GetPlayer(spawner.PlayerIndex);
	}

	public void Remove()
	{
		CharacterManager.Get().UnregisterCharacter(this);
	}

	////////////////////////////////////////////////////////////////////

	//void Init(MovementController controller);

	//MovementController GetController();

	////////////////////////////////////////////////////////////////////

	public abstract float GetLive();

	public abstract void Regenerate(float value);

	public abstract void TakeDamage(float value);

	////////////////////////////////////////////////////////////////////

	public abstract float GetBoost();

	public abstract void GainBoost(float value);

	public abstract void UseBoost(float value);

	////////////////////////////////////////////////////////////////////

	/// Try using a special ability, return true if successful
	public abstract bool UseSpecial(AttackContext context);

	/// Try using a melee attack, return true if successful
	public abstract bool UseMelee(AttackContext context);

	/// Try using a ranged attack, return true if successful
	public abstract bool UseRanged(AttackContext context);

	////////////////////////////////////////////////////////////////////

	public abstract void DoMeleeDamage(DamageContext context);

	public abstract void DoRangedDamage(DamageContext context);

	public abstract void DoSpecialDamage(DamageContext context);

	////////////////////////////////////////////////////////////////////

	public abstract bool CanMove();

	public abstract void Move(float deltaTime);

	public abstract bool CanJump();

	public abstract void Jump(float deltaTime);

	public abstract bool CanFly();

	public abstract void Fly(float deltaTime);

	public abstract bool CanSwim();

	public abstract void Swim(float deltaTime);

	////////////////////////////////////////////////////////////////////

	public bool IsSpawned;

	////////////////////////////////////////////////////////////////////

	protected Player Owner;
}
