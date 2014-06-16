
using UnityEngine;

public delegate void OnBoostHandler(ICharacter character);

public delegate void OnDeathHandler(ICharacter character);

public delegate void OnSpawnedHandler(ICharacter character, CharacterSpawn spawner);

public delegate void OnDecayHandler(ICharacter character);

public delegate void OnRegenerateHandler(ICharacter character);

public delegate void OnDamagedHandler(ICharacter character);

public abstract class ICharacter : MonoBehaviour, IFightable
{

	public Player GetOwningPlayer()
	{
		return Owner;
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Spawns an instance of this character for a player at a spawner.
	/// </summary>
	public ICharacter Create(Player owner)
	{
		IsSpawner = true;
		Object obj = Object.Instantiate(this);//, spawner.transform.localPosition, transform.rotation);
		if (obj is ICharacter)
		{
			ICharacter character = obj as ICharacter;
			character.IsSpawned = true;
			character.Owner = owner;

			CharacterManager.Get().RegisterCharacter(owner.PlayerIndex, character);
			return character;
		}
		return null;
	}

	public void Spawn(CharacterSpawn spawner)
	{
		transform.position = spawner.transform.position;
		OnSpawned(spawner);
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
		return Live;
	}

	public virtual void Regenerate(float value)
	{
		Live += value;
		if (Live > MaxLive)
		{
			Live = MaxLive;
		}
		OnRegenerate();
	}

	////////////////////////////////////////////////////////////////////

	public virtual float GetBoost()
	{
		return Boost;
	}

	public virtual void GainBoost(float value)
	{
		Boost += value;
	}

	////////////////////////////////////////////////////////////////////

	/// Try using a melee attack, return true if successful
	public abstract bool UseMelee(MeleeAttackContext context);

	/// Try using a ranged attack, return true if successful
	public abstract bool UseRanged(RangedAttackContext context);

	/// Try using a special ability, return true if successful
	public abstract bool UseSpecial(SpecialAttackContext context);

	////////////////////////////////////////////////////////////////////

	public virtual void DoMeleeDamage(DamageContext context)
	{
		context.IsMeele = true;
		context.Enemy.OnDamaged(context);
	}

	public virtual void DoRangedDamage(DamageContext context)
	{
		context.IsRanged = true;
		context.Enemy.OnDamaged(context);
	}

	public virtual void DoSpecialDamage(DamageContext context)
	{
		context.IsSpecial = true;
		context.Enemy.OnDamaged(context);
	}

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

	public virtual void OnDamaged(DamageContext damage)
	{
		if (IsDead) return;

		Live -= damage.RollDamage();
		if (Live <= 0)
		{
			Live = 0;
			OnDeath();
			return;
		}

		if (DamagedEvent != null)
			DamagedEvent(this);
	}

	public virtual void OnDeath()
	{
		if (IsDead) return;

		Debug.Log(this + ", owned by player " + GetOwningPlayer().PlayerIndex + " died!");

		isDead = true;

		if (DeathEvent != null)
			DeathEvent(this);
	}

	public virtual void OnDecay()
	{
		if (isDecayed) return;
		if (!isDead)
		{
			Debug.LogError("Character is not dead? There was an error, sorry :(");
			return;
		}
		
		Debug.Log(this + ", owned by player " + GetOwningPlayer().PlayerIndex + " finally decayed!");

		isDecayed = true;

		if (DecayEvent != null)
			DecayEvent(this);
	}

	public virtual void OnRegenerate()
	{
		if (IsDead) return;
		if (RegenerateEvent != null)
			RegenerateEvent(this);
	}

	public virtual void OnBoost()
	{
		if (IsDead) return;
		Boost = 0;
		if (BoostEvent != null)
			BoostEvent(this);
	}

	public virtual void OnSpawned(CharacterSpawn spawner)
	{
		Live = MaxLive;
		Boost = 0;
		isDead = false;
		isDecayed = false;
		
		Debug.Log(this + ", owned by player " + GetOwningPlayer().PlayerIndex + " was spawned!");

		if (SpawnedEvent != null)
			SpawnedEvent(this, spawner);
	}

	public bool IsDead
	{
		get
		{
			return isDead && Live <= 0;
		}
	}	

	public bool IsDecayed
	{
		get
		{
			return isDecayed && IsDead;
		}
	}
	
	public virtual CharacterType CharacterType
	{
		get
		{
			return CharacterType.None;
		}
	}

	////////////////////////////////////////////////////////////////////

	public bool IsSpawned;
	public float MaxLive = 100f;
	public float MaxBoost = 100f;

	public float Live;
	public float Boost;

	////////////////////////////////////////////////////////////////////

	public MeleeAttackContext MeleeAttack;
	public RangedAttackContext RangedAttack;
	public SpecialAttackContext SpecialAttack;
	
	////////////////////////////////////////////////////////////////////
	
	public event OnBoostHandler BoostEvent;
	public event OnDeathHandler DeathEvent;
	public event OnSpawnedHandler SpawnedEvent;
	public event OnDecayHandler DecayEvent;
	public event OnDamagedHandler DamagedEvent;
	public event OnRegenerateHandler RegenerateEvent;

	////////////////////////////////////////////////////////////////////

	protected bool IsSpawner;
	protected Player Owner;

	////////////////////////////////////////////////////////////////////
	 
	bool isDead;
	bool isDecayed;

}
