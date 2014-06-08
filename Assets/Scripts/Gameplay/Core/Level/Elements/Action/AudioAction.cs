using UnityEngine;
using System.Collections.Generic;

public class AudioAction : AbstractAction
{
	protected override void DoAction(Component other)
	{
		if (ClipsToPlay.Length > 0)
		{
			for (int i = 0; i < ClipsToPlay.Length; i++)
			{
				Vector3 AudioOrigin = transform.position - other.transform.position;
				AudioSource.PlayClipAtPoint(ClipsToPlay [i], AudioOrigin);
			}
		}
	}

	public AudioClip[] ClipsToPlay;
}

