using UnityEngine;
using System.Collections;

public class CharacterDespawn : BoxTrigger
{

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	#region implemented abstract members of TriggerElement
	
	protected override void DoTrigger(UnityEngine.Component other)
	{
		ICharacter character = other.gameObject.GetComponent<ICharacter>();
		// trigger only for characters
		if (character != null)
		{
			Level.DoDelete(character);
		}
	}
	
	#endregion
}
