using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(AudioSource))]
public class MovingAudioSource : MonoBehaviour
{
	void Start()
	{
		source = GetComponent<AudioSource>();
		players = CharacterManager.Get().Characters.Count;
		staticPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{	
		transform.position = positionAudioSource();
	}
	
	private Vector3 positionAudioSource()
	{
		//pick character nearer to source to determine new position
		if (players > 1)
		{
			//distance between audiosource and character
			float p1 = Vector3.Distance(staticPosition, CharacterManager.Get().Characters [0].transform.position);
			float p2 = Vector3.Distance(staticPosition, CharacterManager.Get().Characters [1].transform.position);
			
			if (p2 <= p1)
			{
				return  staticPosition - CharacterManager.Get().Characters [1].transform.position;	
			}
			else
			{
				return  staticPosition - CharacterManager.Get().Characters [0].transform.position;
			}
			
			
		}
		else
		{
			return  staticPosition - CharacterManager.Get().Characters [0].transform.position;
		}
		
	}
	
	private AudioSource source;
	private int players;
	private Vector3 staticPosition;
}
