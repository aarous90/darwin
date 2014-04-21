using System.Collections.Generic;
using UnityEngine;

public class SectorData
{
	public SectorData(int modulesPerSectorCount)
	{
		this.modulesPerSectorCount = modulesPerSectorCount;
	}
	
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

	int modulesPerSectorCount;
}


