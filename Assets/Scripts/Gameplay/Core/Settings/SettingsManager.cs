
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
	public struct LevelSettings
	{
		public int PlayerCount;
		public int[] PreferedLayer;
		public int SectorCount;
		public int ModuleCount;
	}

	////////////////////////////////////////////////////////////////////

	public static SettingsManager Get()
	{
		GameObject manager = GameObject.Find("SettingsManager");
		if (manager != null)
		{
			return manager.GetComponent<SettingsManager>();
		}
		return null;
	}
		
	// Use this for initialization
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);

		currentLevelSetings = new LevelSettings();

		currentLevelSetings.PlayerCount = PlayerCount;
		currentLevelSetings.PreferedLayer = PreferedLayer;
//		currentLevelSetings.PreferedLayer[0] = -1;
//		currentLevelSetings.PreferedLayer[1] = -1;
		currentLevelSetings.SectorCount = SectorCount;
		currentLevelSetings.ModuleCount = ModuleCount;
	}
		
	// Update is called once per frame
	void Update()
	{
			
	}

	////////////////////////////////////////////////////////////////////

	public void ApplyLevelSettings(LevelSettings settings)
	{
		if (settings.PlayerCount > 0 && settings.PreferedLayer != null)
		{
			currentLevelSetings = settings;
		}
	}

	////////////////////////////////////////////////////////////////////

	public LevelSettings CurrentLevelSetings
	{
		get
		{
			return currentLevelSetings;
		}
	}

	////////////////////////////////////////////////////////////////////
	
	public int SectorCount;
	public int ModuleCount;

	public int[] PreferedLayer;
	public int PlayerCount;

	////////////////////////////////////////////////////////////////////

	private LevelSettings currentLevelSetings;
}
