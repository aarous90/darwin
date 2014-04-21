
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		Load(Generate(GeneratorSectorBowl));
	}
	
	// Update is called once per frame
	void Update()
	{
		if (isLevelGenerated && isLevelLoaded)
		{

		}
	}
	
	////////////////////////////////////////////////////////////////////

	public class LevelData
	{
		public List<SectorData> Sectors = new List<SectorData>();
	}

	public class SectorData
	{
		public SectorData()
		{

		}

		public void Generate(Module[] modules)
		{
			if (modules == null)
			{
				throw new System.ArgumentNullException("modules");
			}

			List<Module> moduleBowl = new List<Module>(modules);
			int maxModules = Mathf.Min(modules.Length, ModulesPerSectorCount);
			Module m = null;
			
			for (int i = 0; i < maxModules; i++)
			{
				m = moduleBowl[randomizer.Next(moduleBowl.Count)];
				Modules.Add(m);
				moduleBowl.Remove(m);
			}
		}

		public void Load()
		{
			foreach (Module m in Modules)
			{
				Object.Instantiate(m, new Vector3(), new Quaternion());
            }
        }

		public List<Module> Modules = new List<Module>();
	}

	public LevelData Generate(Sector[] sectors)
	{
		if (sectors == null)
		{
			throw new System.ArgumentNullException("sectors");
		}

		LevelData data = new LevelData();
		List<Sector> sectorBowl = new List<Sector>(sectors);
		int maxSector = Mathf.Min(sectors.Length, SectorCount);
		Sector s = null;

		for (int i = 0; i < maxSector; i++)
		{
			s = sectorBowl[randomizer.Next(sectorBowl.Count)];
			SectorData sd = new SectorData();
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

	static public int SectorCount = 2;
	static public int ModulesPerSectorCount = 5;
	static public int Seed = 42;

	public Sector[] GeneratorSectorBowl;

	////////////////////////////////////////////////////////////////////
	
	static System.Random randomizer = new System.Random(Seed);

	LevelData levelData = new LevelData();

	bool isLevelGenerated;

	bool isLevelLoaded;

}


