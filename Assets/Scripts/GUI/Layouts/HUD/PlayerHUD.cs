using UnityEngine;
using System.Collections;

public class PlayerHUD : GUIItem
{
	protected override void Init()
	{
		player = PlayerManager.Get().GetPlayer(PlayerIndex);

		if (player == null)
		{
			Debug.LogError("No player found for index + " + PlayerIndex + " !");
			return;
		}

		player.PlayerFinishesEvent += new OnPlayerFinishesHandler(OnPlayerFinishes);
		backgroundGUI = GetComponent<GUITexture>();
		backgroundGUI.enabled = false;

		cam = CameraManager.Get().GetCamera(PlayerIndex);
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
		if (player == null || player.GetCharacter() == null)
		{
			return;
		}
		UpdateLiveBar();

		playerPosition = cam.WorldToViewportPoint(player.GetCharacter().transform.position);
		playerPosition.Scale(new Vector3(cam.pixelWidth, cam.pixelHeight, 1));
		playerPosition.y = cam.pixelHeight-playerPosition.y;
	}

	void UpdateLiveBar()
	{
		livePercentage = player.GetCharacter().GetLive() * 0.01f;
	}

	void OnPlayerFinishes(Player p)
	{

	}

	void OnGUI()
	{
		GUI.BeginGroup(guiRect);
			GUI.BeginGroup(new Rect(
				Position.x + playerPosition.x, 
				Position.y + playerPosition.y, Size.x, Size.y));
				GUI.DrawTexture(new Rect(
					9,
					112, 
					LiveBar.width * livePercentage, 
					LiveBar.height),
				                LiveBar);

				GUI.DrawTexture(new Rect(
					0, 
					0, 
			        backgroundGUI.texture.width, 
					backgroundGUI.texture.height), 
				                backgroundGUI.texture);
			GUI.EndGroup();
		GUI.EndGroup();
	}

	////////////////////////////////////////////////////////

	public Texture2D LiveBar;
	
	public Vector2 Position;
	
	public Vector2 Size;

	public int PlayerIndex;

	////////////////////////////////////////////////////////

	GUITexture backgroundGUI;

	float livePercentage;

	Player player = null;

	Vector3 playerPosition;

	Camera cam;

	Rect guiRect;
}
