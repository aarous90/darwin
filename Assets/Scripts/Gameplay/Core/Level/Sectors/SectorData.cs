using System.Collections.Generic;
using UnityEngine;

public class SectorData
{
	public SectorData(int modulesPerSectorCount)
	{
		this.modulesPerSectorCount = modulesPerSectorCount;
		
		spawnsUnused = new List<int>(new int[] {0, 1, 2});
		reachedFighting = new bool[ControllerManager.Get().GetControllers().Count];
	}

	////////////////////////////////////////////////////////////////////

	public void Generate(Sector sector)
	{
		if (sector == null)
		{
			throw new System.ArgumentNullException("modules");
		}

		generatorSector = sector;
		
		List<Module> moduleBowl = new List<Module>(sector.Modules);
		int maxModules = Mathf.Min(sector.Modules.Length, modulesPerSectorCount);
		Module m = null;

		for (int i = 0; i < maxModules; i++)
		{
			m = moduleBowl[Util.Randomizer.Next(moduleBowl.Count)];
			gerneratorModules.Add(m);
			moduleBowl.Remove(m);
		}

	}

	////////////////////////////////////////////////////////////////////

	public void BeginSector(ConnectorElement outConnector)
	{
		lastOutConnector = outConnector;
		spawnModule = InstantiateModule(generatorSector.Spawn) as SpawnModule;
	}

	public void Load()
	{
		foreach (Module m in GenreatorModules)
		{
			Module newModule = InstantiateModule(m);
			if (newModule != null)
			{
				sectorModules.Add(newModule);
			}
		}
	}
	
	public void EndSector(out ConnectorElement outConnector)
	{
		fightingModule = InstantiateModule(generatorSector.Fighting) as FightingModule;
		outConnector = lastOutConnector;
	}

	////////////////////////////////////////////////////////////////////

	Vector3 PlaceModule(ConnectorElement outConnector, Module module)
	{
		if (module == null)
			throw new System.ArgumentNullException("module");

		Vector3 newPos;
		// first connector is null!
		if (outConnector == null)
		{
			newPos = new Vector3(0, 0, 0);
		}
		else
		{
			newPos = -module.transform.position + outConnector.transform.position;// outConnector.transform.localPosition);
		}
		return newPos;
	}

	Module InstantiateModule(Module module)
	{
		Object obj = 
			Object.Instantiate(module, 
			                   PlaceModule(lastOutConnector, module), 
			                   new Quaternion());
		if (obj is Module)
		{
			Module loaded = obj as Module;
			lastOutConnector = loaded.OutConnector;
			return loaded;
		}
		return null;
	}

	////////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// Gets the generator modules. 
	/// The list of modules that will be instantiated.
	/// </summary>
	/// <value>The sector modules.</value>
	public List<Module> GenreatorModules
	{
		get
		{
			return gerneratorModules;
		}
	}
	/// <summary>
	/// Gets the sector modules.
	/// </summary>
	/// <value>The sector modules.</value>
	public List<Module> SectorModules
	{
		get
		{
			return sectorModules;
		}
	}

	public Sector GeneratorSector
	{
		get
		{
			return generatorSector;
		}
	}

	public SpawnModule SpawnModule
	{
		get
		{
			return spawnModule;
		}
	}

	public FightingModule FightingModule
	{
		get
		{
			return fightingModule;
		}
	}

	public string Name
	{
		get
		{
			return generatorSector.name;
		}
	}

	public List<int> SpawnsUnused
	{
		get
		{
			return spawnsUnused;
		}
		set
		{
			spawnsUnused = value;
		}
	}

	public bool[] ReachedFighting
	{
		get
		{
			return reachedFighting;
		}
	}

	////////////////////////////////////////////////////////////////////

	/// <summary>
	/// The modules that are used to generate the sector with the LevelGenerator.
	/// </summary>
	List<Module> gerneratorModules = new List<Module>();
	/// <summary>
	/// The generated sector modules.
	/// </summary>
	List<Module> sectorModules = new List<Module>();

	/// <summary>
	/// The sector that is used (with its gerneratorModules) to create an instance.
	/// </summary>
	Sector generatorSector;

	////////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// The spawning module.
	/// </summary>
	SpawnModule spawnModule;

	/// <summary>
	/// The fighting module.
	/// </summary>
	FightingModule fightingModule;

	/// <summary>
	/// The amount of modules per sector.
	/// </summary>
	int modulesPerSectorCount;

	/// <summary>
	/// The last out connector used in level loading.
	/// </summary>
	ConnectorElement lastOutConnector;
	
	List<int> spawnsUnused;
	bool[] reachedFighting;
}


