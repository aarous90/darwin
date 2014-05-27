using UnityEngine;
using System.Collections;

public class WaterZone : BoxTrigger
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
		if (IsCharacter(other, CharacterType.Ground, out character))
		{
			OtherDamage.OnAction(character);
		}
		else if (IsCharacter(other, CharacterType.Air, out character))
		{
			OtherDamage.OnAction(character);
		}
	}

	public DamageAction OtherDamage;
}
