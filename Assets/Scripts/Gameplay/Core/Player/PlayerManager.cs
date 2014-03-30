using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager Get()
	{
		GameObject im = GameObject.Find("PlayerManager");
		if (im != null)
		{
			return im.GetComponent<PlayerManager>();
		}
		return null;
	}
	
	// Use this for initialization
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}


}
