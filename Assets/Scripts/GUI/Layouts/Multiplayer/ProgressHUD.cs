using UnityEngine;
using System.Collections;

public class ProgressHUD : GUIItem
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
		progressPercentage = Level.GetLevelProgress(player.GetCharacter());
    }
    
    void OnGUI()
	{
		if (player == null)
		{
			return;   
        }

		Display d = Display.displays[0];
		// Draw the progress bar
        GUI.DrawTexture(new Rect(
			transform.position.x - TimelineBar.width * (1 - progressPercentage),
			(1 - transform.position.y) * d.renderingHeight - TimelineBar.height, 
			TimelineBar.width, 
			TimelineBar.height),
		                TimelineBar);
		// draw the progress background
		GUI.DrawTexture(new Rect(
			transform.position.x,
			(1 - transform.position.y) * d.renderingHeight - TimelineBackground.height, 
			TimelineBackground.width, 
			TimelineBackground.height),
		                TimelineBackground);
		// draw the character icon
		GUI.DrawTexture(new Rect(
			TimelineBar.width * progressPercentage - CharacterIcon.width * 0.5f,
			(1 - transform.position.y) * d.renderingHeight - CharacterIcon.height, 
			CharacterIcon.width, 
			CharacterIcon.height),
		                CharacterIcon);
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

	float progressPercentage = 0;

	GUITexture progressHUD;

	Player player;
}
