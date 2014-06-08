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
				Vector3 AudioOrigin = new Vector3(transform.position.x - other.transform.position.x, 0, 0);
				AudioSource.PlayClipAtPoint(ClipsToPlay [i], AudioOrigin);
			}
		}
	}

	public AudioClip[] ClipsToPlay;
}

