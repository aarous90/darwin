using UnityEngine;
using System.Collections;

public class DamageTrigger : AbstractTrigger, IDamageable
{

	// Use this for initialization
	void Start()
	{
		currentDamage = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	#region IDamageable implementation

	public void OnDamaged(DamageContext damage)
	{
		currentDamage += damage.RollDamage();

		if (currentDamage >= TriggerDamage)
		{
			TriggerAction(this);
		}
	}

	public void OnDeath()
	{

	}

	public void OnDecay()
	{

	}

	#endregion

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

	public float TriggerDamage;

	float currentDamage;
}
