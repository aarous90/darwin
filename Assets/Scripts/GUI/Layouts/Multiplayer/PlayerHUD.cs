using UnityEngine;
using System.Collections;

public class PlayerHUD : GUIItem
{
	protected override void Init()
	{
		player = PlayerManager.Get().GetPlayer(PlayerIndex);
		backgroundGUI = GetComponent<GUITexture>();
		backgroundGUI.enabled = false;
		base.Init();
	}

	// Update is called once per frame
	void Update()
	{
		if (player == null)
		{
			return;
		}
		UpdateLiveBar();
	}

	void UpdateLiveBar()
	{
		livePercentage = player.GetCharacter().GetLive() * 0.01f;
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(
			0,
			0, 
			LiveBar.width * livePercentage, 
			LiveBar.height),
		                LiveBar, 
		                ScaleMode.ScaleToFit, 
		                true);

		GUI.DrawTexture(new Rect(
			0, 
			0, 
	        backgroundGUI.texture.width, 
			backgroundGUI.texture.height), 
		                backgroundGUI.texture, 
		                ScaleMode.ScaleToFit, 
		                true);

//		GUI.DrawTexture(new Rect(
//			100, 100, 
//			100, 100),
//		                LiveBar, 
//		                ScaleMode.ScaleToFit, 
//		                true);
	}

	////////////////////////////////////////////////////////

	public Texture2D LiveBar;

	public int PlayerIndex;

	////////////////////////////////////////////////////////

	GUITexture backgroundGUI;

	float livePercentage;

	Player player = null;
}
