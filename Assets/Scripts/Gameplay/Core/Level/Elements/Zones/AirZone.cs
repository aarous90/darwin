﻿using UnityEngine;
using System.Collections;

public class AirZone : BoxTrigger
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
		else if (IsCharacter(other, CharacterType.Water, out character))
		{
			OtherDamage.OnAction(character);
		}
	}
	
	public DamageAction OtherDamage;
}
