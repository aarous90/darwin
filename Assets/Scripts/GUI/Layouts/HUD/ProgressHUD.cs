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

		cam = CameraManager.Get().GetCamera(PlayerIndex);
		if (cam == null)
		{
			throw new UnityException("No camera for player " + PlayerIndex + " HUD found!");
		}
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

		float aspect = ((float) TimelineBackground.height / TimelineBackground.width);

		GUI.BeginGroup(new Rect(Position.x, Position.y + cam.pixelHeight - TimelineBackground.height, cam.pixelWidth, cam.pixelWidth * aspect));

			// Draw the progress bar
	        GUI.DrawTexture(new Rect(
				0,
				120, 
				cam.pixelWidth * progressPercentage, 
				TimelineBar.height),
			                TimelineBar);
			// draw the progress background
			GUI.DrawTexture(new Rect(
				0,
				0, 
			cam.pixelWidth, TimelineBackground.height ),
			                TimelineBackground);
			// draw the character icon
			GUI.DrawTexture(new Rect(
				cam.pixelWidth * progressPercentage - CharacterIcon.width * 0.5f,
				CharacterIcon.height, 
				CharacterIcon.width, 
				CharacterIcon.height),
			                CharacterIcon);

		GUI.EndGroup();
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

	public Vector3 Position;

	////////////////////////////////////////////////////////

	float progressPercentage = 0;

	GUITexture progressHUD;

	Player player;

	Camera cam;
}
