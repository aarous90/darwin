using UnityEngine;
using System.Collections;

public class GroundZone : BoxTrigger
{
	
	protected override void OnTriggerEnter(Collider other)
	{
		
	}
	
	protected override void OnTriggerExit(Collider other)
	{
		
	}
	
	protected override void OnTriggerStay(Collider other)
	{
		ICharacter character;
		if (IsCharacter(other, CharacterType.Water, out character))
		{
			OtherDamage.OnTriggered(character);
		}
		else if (IsCharacter(other, CharacterType.Air, out character))
		{
			OtherDamage.OnTriggered(character);
		}
	}
	
	public DamageAction OtherDamage;
}
