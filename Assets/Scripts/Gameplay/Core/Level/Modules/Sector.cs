using System;
using UnityEngine;

public class Sector : MonoBehaviour
{
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	////////////////////////////////////////////////////////////////////

	public void Load(SectorData sectorData)
	{
		data = sectorData;
	}
	
	////////////////////////////////////////////////////////////////////
	
	public Module[] Modules;

	public string SectorName;

	SectorData data = null;
}

