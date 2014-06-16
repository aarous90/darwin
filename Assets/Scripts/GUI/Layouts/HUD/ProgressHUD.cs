using UnityEngine;
using System.Collections;

public class ProgressHUD : GUIItem
{
	protected override void Init()
	{
		player = PlayerManager.Get().GetPlayer(PlayerIndex);
		progressHUD = GetComponent<GUITexture>();
		progressHUD.enabled = false;

		cam = CameraManager.Get().GetCamera(PlayerIndex);
		if (player == null)
		{
			Debug.LogError("No player found for index + " + PlayerIndex + " !");
			return;
		}
		if (cam == null)
		{
			Debug.LogError("No camera for player " + PlayerIndex + " HUD found!");
			return;
		}

		guiRect = new Rect(cam.pixelRect);
		if (PlayerManager.Get().GetPlayerCount() > 1)
		{
			guiRect.y = guiRect.height - guiRect.y;
		}

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

		float aspect = ((float) TimelineBackground.height / TimelineBackground.width);
		float aspect2 = ((float) TimelineBar.height / TimelineBar.width);

		GUI.BeginGroup(guiRect);
			GUI.BeginGroup(
				new Rect(	Position.x, 
		         			Position.y + cam.pixelHeight - guiRect.width * aspect, 
		         			guiRect.width, 
		         			guiRect.width * aspect));



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
				GUI.BeginGroup(
					new Rect(0, TimelineBackground.height - TimelineBar.height, cam.pixelWidth * progressPercentage, guiRect.width * aspect));
				
					// Draw the progress bar
					GUI.DrawTexture(
						new Rect(0, 0, guiRect.width, guiRect.width * aspect2), 
						TimelineBar);
				
				GUI.EndGroup();
			GUI.EndGroup();
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
			{
				Debug.LogError("Invalid player object!");
			}
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

	Rect guiRect;
}
