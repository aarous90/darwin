using UnityEngine;
using System.Collections;

public class SinkingAction : AbstractAction
{
	// Use this for initialization
	void Start()
	{
		initialPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (sinking)
		{
			if (currentSink < MaxSink)
			{
				float translate = SinkingSpeed * Time.deltaTime;
				currentSink += translate;
				transform.Translate(0, -translate, 0);
			}
		}
		else
		{
			if (currentSink > 0)
			{
				float translate = SinkingSpeed * Time.deltaTime;
				currentSink -= translate;
				transform.Translate(0, translate, 0);
			}
		}
	}

	#region implemented abstract members of ActionElement

	protected override void DoAction(Collider other)
	{
		sinking = !sinking;
	}

	#endregion

	bool sinking = false;

	Vector3 initialPosition;

	float currentSink = 0.0f;

	public float SinkingSpeed = 1.5f;

	public float MaxSink = 1f;


}
