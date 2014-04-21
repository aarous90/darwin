using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		if (Spawns.Length != 3)
		{
			throw new UnityException("Each module needs three spawns for air, ground and water!");
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	/// <summary>
	/// The spawns, must be exactly two!
	/// </summary>
	public CharacterSpawn[] Spawns;
}
