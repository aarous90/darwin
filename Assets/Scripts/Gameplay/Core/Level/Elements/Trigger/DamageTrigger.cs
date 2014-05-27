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
			InvokeTrigger(this);
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

	protected override void DoTrigger(UnityEngine.Component other)
	{
		if (!Active) return;

		foreach (AbstractAction a in Actions)
		{
			if (a != null)
				a.OnAction(other);
		}
	}

	#endregion

	public float TriggerDamage;

	float currentDamage;
}
