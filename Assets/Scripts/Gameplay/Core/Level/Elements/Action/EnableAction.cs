using UnityEngine;
using System.Collections;

public class EnableAction : AbstractAction
{
	#region implemented abstract members of AbstractAction

	protected override void DoAction(Component other)
	{
		if (ActionToEnable != null) 
		{
			ActionToEnable.Active = true;
		}

		if (TriggerToEnable != null) 
		{
			TriggerToEnable.Active = true;
		}
	}

	#endregion

	public AbstractAction ActionToEnable;

	public AbstractTrigger TriggerToEnable;
}
