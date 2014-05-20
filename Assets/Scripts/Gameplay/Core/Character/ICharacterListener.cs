using System;

public interface ICharacterListener
{
	void OnDamaged(ICharacter character);
	
	void OnDeath(ICharacter character);
	
	void OnDecay(ICharacter character);
	
	void OnRegenerate(ICharacter character);
	
	void OnBoost(ICharacter character);

	void OnSpawned(ICharacter character);
}

