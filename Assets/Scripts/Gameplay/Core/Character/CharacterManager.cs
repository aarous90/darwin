using UnityEngine;

/// <summary>
/// Character manager.
/// </summary>
public class CharacterManager : MonoBehaviour
{
	public static CharacterManager Get()
	{
		GameObject manager = GameObject.Find("CharacterManager");
		if (manager != null)
		{
			return manager.GetComponent<CharacterManager>();
		}
		return null;
	}

	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	void Update()
	{

	}

	////////////////////////////////////////////////////////////////////


}
