
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
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

	public LevelData Generate(Sector[] sectors)
	{
		if (sectors == null)
		{
			throw new System.ArgumentNullException("sectors");
		}

		randomizer = Util.Randomizer;
		LevelData data = new LevelData();
		List<Sector> sectorBowl = new List<Sector>(sectors);
		int maxSector = Mathf.Min(sectors.Length, SectorCount);
		Sector s = null;

		for (int i = 0; i < maxSector; i++)
		{
			s = sectorBowl[randomizer.Next(sectorBowl.Count)];
			SectorData sd = new SectorData(ModulesPerSectorCount);
			sd.Generate(s.Modules);
			data.Sectors.Add(sd);
			sectorBowl.Remove(s);
		}

		isLevelGenerated = true;
		return data;
	}

	public void Load(LevelData data)
	{
		foreach (var sd in data.Sectors)
		{
			sd.Load();
		}
        isLevelLoaded = true;
	}

	public bool IsLevelGenerated
	{
		get
		{
			return isLevelGenerated;
		}
	}

	public bool IsLevelLoaded
	{
		get
		{
			return isLevelLoaded;
		}
	}

	////////////////////////////////////////////////////////////////////

	public int SectorCount = 2;
	public int ModulesPerSectorCount = 5;
	public int Seed = 42;

	////////////////////////////////////////////////////////////////////
	
	System.Random randomizer;

	bool isLevelGenerated;

	bool isLevelLoaded;

}


