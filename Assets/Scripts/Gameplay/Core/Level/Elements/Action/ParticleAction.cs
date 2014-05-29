using UnityEngine;
using System.Collections.Generic;

public class ParticleAction : AbstractAction
{

	void Update()
	{
		if (Lifetime > 0 && instantiatedObjects.Count > 0)
		{
			runningTime += Time.deltaTime;
			if (runningTime > Lifetime)
			{
				foreach (Object o in instantiatedObjects)
				{
					ParticleEffect pe = o as ParticleEffect;
					pe.gameObject.particleEmitter.emit = false;
					//Object.Destroy(o);

				}
				instantiatedObjects.Clear();
			}
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
					this.gameObject.transform.position, Quaternion.identity));
				
				ParticleEffect pe = instance as ParticleEffect;
				pe.gameObject.particleEmitter.emit = true;

				ParticleAnimator pa = pe.gameObject.GetComponent<ParticleAnimator>();

				pa.autodestruct = Lifetime > 0;
			}
		}
	}

	#endregion

	public ParticleEffect[] EffectsToPlay;
	public float Lifetime = 0;

	private LinkedList<Object> instantiatedObjects = new LinkedList<Object>();
	private float runningTime;
}

