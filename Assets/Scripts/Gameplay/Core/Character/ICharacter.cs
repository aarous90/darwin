
using UnityEngine;

public abstract class ICharacter : MonoBehaviour
{

	public Player GetOwningPlayer()
	{
		return Owner;
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Spawns an instance of this character for a player at a spawner.
	/// </summary>
	public ICharacter Spawn(Player owner, CharacterSpawn spawner)
	{
		IsSpawner = true;
		Object obj = Object.Instantiate(this, spawner.transform.localPosition, transform.rotation);
		if (obj is ICharacter)
		{
			ICharacter character = obj as ICharacter;
			character.IsSpawned = true;
			character.Owner = owner;
			character.live = MaxLive;
			character.boost = 0;
			CharacterManager.Get().RegisterCharacter(owner.PlayerIndex, character);
			return character;
		}
		return null;
	}

	/// <summary>
	/// Remove this instance.
	/// </summary>
	public void Remove()
	{
		CharacterManager.Get().UnregisterCharacter(Owner.PlayerIndex);
	}

	////////////////////////////////////////////////////////////////////

	//void Init(MovementController controller);

	//MovementController GetController();

	////////////////////////////////////////////////////////////////////

	public virtual float GetLive()
	{
		return live;
	}

	public virtual void Regenerate(float value)
	{
		live += value;
		if (live > MaxLive)
		{
			live = MaxLive;
		}
		OnRegenerate();
	}

	public virtual void TakeDamage(float value)
	{
		live -= value;
		if (live <= 0)
		{
			live = 0;
			OnDeath();
			return;
		}
		OnDamaged();
	}

	////////////////////////////////////////////////////////////////////

	public virtual float GetBoost()
	{
		return boost;
	}

	public virtual void GainBoost(float value)
	{
		boost += value;
	}

	public virtual void UseBoost(float value)
	{
		boost = 0;
	}

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

	public abstract void OnDamaged();

	public abstract void OnDeath();

	public abstract void OnRegenerate();

	public abstract void OnBoost();

	////////////////////////////////////////////////////////////////////

	public bool IsSpawned;
	public float MaxLive = 100f;
	public float MaxBoost = 100f;

	////////////////////////////////////////////////////////////////////

	protected bool IsSpawner;
	protected Player Owner;

	////////////////////////////////////////////////////////////////////
	 
	float live;
	float boost;


}
