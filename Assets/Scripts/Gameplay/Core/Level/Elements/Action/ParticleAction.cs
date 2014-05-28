using UnityEngine;
using System.Collections.Generic;

public class ParticleAction : AbstractAction
{

	void Update()
	{
		if (Lifetime > 0)
		{

		}
	}

	#region implemented abstract members of AbstractAction

	protected override void DoAction(UnityEngine.Component other)
	{
		if (EffectsToPlay.Length > 0)
		{
			for (int i = 0; i < EffectsToPlay.Length; i++)
			{
				Object instance;

				instantiatedObjects.AddLast(instance = Object.Instantiate(
					EffectsToPlay [i], 
					this.gameObject.transform.position, 
					this.gameObject.transform.rotation));

				if (Lifetime > 0)
				{
					Object.Destroy(instance, Lifetime);
				}
			}
		}
	}

	#endregion

	public ParticleEffect[] EffectsToPlay;
	public float Lifetime = 0;
	private LinkedList<Object> instantiatedObjects = new LinkedList<Object>();
}

