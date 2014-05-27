
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		sectorCount = SettingsManager.Get().CurrentLevelSetings.SectorCount;
		modulesPerSectorCount = SettingsManager.Get().CurrentLevelSetings.ModuleCount;
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

		LevelData data = new LevelData();
		List<Sector> sectorBowl = new List<Sector>(sectors);
		int maxSector = Mathf.Min(sectors.Length, sectorCount);
		Sector s = null;

		for (int i = 0; i < maxSector; i++)
		{
			s = sectorBowl[Util.Randomizer.Next(sectorBowl.Count)];
			SectorData sd = new SectorData(modulesPerSectorCount);
			sd.Generate(s);
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
			sd.BeginSector(lastOutConnector);
			sd.Load();
			sd.EndSector(out lastOutConnector);
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

	private int sectorCount;
	private int modulesPerSectorCount;

	////////////////////////////////////////////////////////////////////

	bool isLevelGenerated;

	bool isLevelLoaded;

	ConnectorElement lastOutConnector = null;

}


