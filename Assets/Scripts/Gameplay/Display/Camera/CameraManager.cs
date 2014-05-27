using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera manager.
/// </summary>
public class CameraManager : MonoBehaviour
{
	public static CameraManager Get()
	{
		GameObject manager = GameObject.Find("CameraManager");
		if (manager != null)
		{
			return manager.GetComponent<CameraManager>();
		}
		return null;
	}
	
	void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void Add(CameraController controller)
	{
		controllers.Add(controller.PlayerIndex, controller);
	}

	public void Clear()
	{
		controllers.Clear();
	}

	public Camera GetCamera(int playerIndex)
	{
		CameraController c;

		if (controllers.TryGetValue(playerIndex, out c) 
		    && c != null 
		    && c.camera != null)
		{
			return c.camera;
		}

		return null;
	}

	Dictionary<int, CameraController> controllers = new Dictionary<int, CameraController>();
}

