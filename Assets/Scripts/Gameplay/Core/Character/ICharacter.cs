
public interface ICharacter 
{

	Player GetOwningPlayer();

	////////////////////////////////////////////////////////////////////

	void Spawn();

	////////////////////////////////////////////////////////////////////

	//void Init(MovementController controller);

	//MovementController GetController();

	////////////////////////////////////////////////////////////////////

	float GetLive();

	void Regenerate(float value);

	void TakeDamage(float value);

	////////////////////////////////////////////////////////////////////

	float GetBoost();

	void GainBoost(float value);

	void UseBoost(float value);

	////////////////////////////////////////////////////////////////////

	/// Try using a special ability, return true if successful
	bool UseSpecial(AttackContext context);

	/// Try using a melee attack, return true if successful
	bool UseMelee(AttackContext context);

	/// Try using a ranged attack, return true if successful
	bool UseRanged(AttackContext context);

	////////////////////////////////////////////////////////////////////

	void DoMeleeDamage(DamageContext context);

	void DoRangedDamage(DamageContext context);

	void DoSpecialDamage(DamageContext context);

	////////////////////////////////////////////////////////////////////

	bool CanMove();

	void Move(float deltaTime);

	bool CanJump();

	void Jump(float deltaTime);

	bool CanFly();

	void Fly(float deltaTime);

	bool CanSwim();

	void Swim(float deltaTime);

	////////////////////////////////////////////////////////////////////
}
