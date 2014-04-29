using UnityEngine;
using System.Collections;

public class Timeline : GUIItem
{
	protected override void Init()
	{
		player = PlayerManager.Get().GetPlayer(PlayerIndex);
		progressHUD = GetComponent<GUITexture>();
		progressHUD.enabled = false;
        base.Init();
    }

	// Update is called once per frame
	void Update()
	{
		if (player == null)
		{
			return;   
        }
		//progressPercentage = 
    }
    
    void OnGUI()
	{
		if (player == null)
		{
			return;   
        }
		// Draw the progress bar
        GUI.DrawTexture(new Rect(
			0,
			0, 
			TimelineBar.width * progressPercentage, 
			TimelineBar.height),
		                TimelineBar, 
		                ScaleMode.ScaleToFit, 
		                true);
		// draw the progress background
		GUI.DrawTexture(new Rect(
			0,
			0, 
			TimelineBackground.width, 
			TimelineBackground.height),
		                TimelineBackground, 
		                ScaleMode.ScaleToFit, 
		                true);
		// draw the character icon
		GUI.DrawTexture(new Rect(
			TimelineBar.width * progressPercentage,
			0, 
			CharacterIcon.width, 
			CharacterIcon.height),
		                CharacterIcon, 
		                ScaleMode.ScaleToFit, 
		                true);
	}

	////////////////////////////////////////////////////////

	public Player Player
	{
		get
		{
			return player;
		}
		set
		{
			if (value != null)
				player = value;
			else
				throw new UnityException("Invalid player object!");
		}
	}

	public Texture2D TimelineBackground;
	public Texture2D TimelineBar;
	public Texture2D CharacterIcon;
	public int PlayerIndex;

	////////////////////////////////////////////////////////

	float progressPercentage;

	GUITexture progressHUD;

	Player player;
}
