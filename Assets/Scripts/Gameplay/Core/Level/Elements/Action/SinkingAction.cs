using UnityEngine;
using System.Collections;

public class SinkingAction : ActionElement
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
				transform.Translate(0, -(currentSink += SinkingSpeed * Time.deltaTime), 0);
			}
		}
		else
		{
			if (currentSink > 0)
			{
				transform.Translate(0, (currentSink -= SinkingSpeed * Time.deltaTime), 0);
			}
		}
	}

	#region implemented abstract members of ActionElement

	protected override void DoAction()
	{
		sinking = !sinking;
	}

	#endregion

	bool sinking = false;

	Vector3 initialPosition;

	float currentSink = 0.0f;

	public float SinkingSpeed = 0.01f;

	public float MaxSink = 1f;


}
