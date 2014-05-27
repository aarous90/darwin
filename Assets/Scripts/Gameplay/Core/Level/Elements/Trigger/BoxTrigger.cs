using UnityEngine;
using System.Collections;

public class BoxTrigger : VolumeTrigger
{	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(0,0,0);
	}

	void TriggerForCharacter(Collider other)
	{
		ICharacter character = null;
		// trigger only for characters
		if ((character = other.gameObject.GetComponent<ICharacter>()) != null)
		{
			TriggerAction(character);
		}
	}

	#region implemented abstract members of TriggerElement

	protected override void TriggerAction(UnityEngine.Component other)
	{
		foreach (AbstractAction a in Actions)
		{
			if (a != null)
				a.OnTriggered(other);
		}
	}

	#endregion

	#region implemented abstract members of VolumeTrigger
	
	protected override void OnTriggerEnter(Collider other)
	{
		if (!TriggerOnEnter || !Active) return;

		TriggerForCharacter(other);
	}
	
	protected override void OnTriggerExit(Collider other)
	{
		if (!TriggerOnExit || !Active) return;
		
		TriggerForCharacter(other);
	}
	
	protected override void OnTriggerStay(Collider other)
	{
		if (!TriggerOnStay || !Active) return;

		TriggerForCharacter(other);
	}

	#endregion

	protected bool IsCharacter(Collider other, CharacterType type, out ICharacter character)
	{
		character = null;
		
		switch (type)
		{
			case CharacterType.Air:
			{
				if ((character = other.gameObject.GetComponent<AirCharacter>()) != null)
				{
					return true;
				}
			}
				break;
			case CharacterType.Ground:
			{
				if ((character = other.gameObject.GetComponent<GroundCharacter>()) != null)
				{
					return true;
				}
			}
				break;
			case CharacterType.Water:
			{
				if ((character = other.gameObject.GetComponent<WaterCharacter>()) != null)
				{
					return true;
				}
			}
				break;
			default:
				break;
		}
		return false;
	}

	public bool TriggerOnEnter = true;

	public bool TriggerOnExit;

	public bool TriggerOnStay;
}
