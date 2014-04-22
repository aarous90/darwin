using System.Collections.Generic;
using UnityEngine;

public class SectorData
{
	public SectorData(int modulesPerSectorCount)
	{
		this.modulesPerSectorCount = modulesPerSectorCount;
	}

	////////////////////////////////////////////////////////////////////

	public void Generate(Module[] modules)
	{
		if (modules == null)
		{
			throw new System.ArgumentNullException("modules");
		}
		
		List<Module> moduleBowl = new List<Module>(modules);
		int maxModules = Mathf.Min(modules.Length, modulesPerSectorCount);
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
	}

	public void Load()
	{
		foreach (Module m in GenreatorModules)
		{
			Object obj = Object.Instantiate(m, PlaceModule(lastOutConnector, m), new Quaternion());
			if (obj is Module)
			{
				Module loaded = obj as Module;
				lastOutConnector = loaded.OutConnector;
				sectorModules.Add(loaded);
			}
		}
	}
	
	public void EndSector(out ConnectorElement outConnector)
	{
		outConnector = lastOutConnector;
	}

	////////////////////////////////////////////////////////////////////

	Vector3 PlaceModule(ConnectorElement outConnector, Module module)
	{
		if (module == null)
			throw new System.ArgumentNullException("module");

		Vector3 newPos;
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

	////////////////////////////////////////////////////////////////////

	public List<Module> GenreatorModules
	{
		get
		{
			return gerneratorModules;
		}
	}

	public List<Module> SectorModules
	{
		get
		{
			return sectorModules;
		}
	}

	////////////////////////////////////////////////////////////////////
	
	List<Module> gerneratorModules = new List<Module>();

	List<Module> sectorModules = new List<Module>();

	int modulesPerSectorCount;

	ConnectorElement lastOutConnector;
}


