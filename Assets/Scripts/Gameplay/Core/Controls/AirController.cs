using System;
using System.Collections.Generic;
using UnityEngine;

public class AirController : IController
{
	#region IController implementation

	public override void Initialize(ICharacter character)
	{
		if (character is AirCharacter)
		{
			this.currentCharacter = character as AirCharacter;
		}
		else
		{
			throw new ArgumentException("Invalid character type!");
		}
	}

	#endregion

	// Use this for initialization
	public override void Start()
	{

	}
	
	// Update is called once per frame
	public override void Update()
	{
		
	}
	
	public override void FixedUpdate()
	{		

		
	}


	AirCharacter currentCharacter;

}
