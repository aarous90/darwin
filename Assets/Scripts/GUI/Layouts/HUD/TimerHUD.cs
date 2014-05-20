using UnityEngine;
using System.Collections;

public class TimerHUD : GUIItem
{

	// Use this for initialization
	protected override void Init()
	{
		player = PlayerManager.Get().GetPlayer(PlayerIndex);
		player.PlayerFinishesEvent += new OnPlayerFinishesHandler(OnPlayerFinishes);
		timerText = GetComponent<GUIText>();
		//timerText.enabled = false;
		playerTimer = new Util.Timer(-1, -1, true);

		cam = CameraManager.Get().GetCamera(PlayerIndex);
		if (cam == null)
		{
			throw new UnityException("No camera for player " + PlayerIndex + " HUD found!");
        }
        
		base.Init();
	}
	
	// Update is called once per frame
	void Update()
	{
		playerTimer.Update();

		float time = playerTimer.RunningTime;
		int seconds = Mathf.FloorToInt(time);
		int mili = (int) ((time - (float) seconds) * 1000.0f);
		int minutes = seconds / 60;
		seconds -= minutes * 60;
		timerText.text = string.Format(
			"{0,00}:{1,00}:{2,000}", 
			new object[] {minutes.ToString("D2"), seconds.ToString("D2"), mili.ToString("D3")});
	}
    
    void OnPlayerFinishes(Player p)
	{
		playerTimer.Stop();
//		switch (PlayerManager.Get().GetPlayerCount())
//		{
//			case 1: 
//				transform.localPosition.Set(
//					Util.OnePlayersPositions.x, 
//					Util.OnePlayersPositions.y, 
//					0);
//				break;
//			case 2:
//				transform.localPosition.Set(
//					Util.TwoPlayersPositions[p.PlayerIndex].x, 
//					Util.TwoPlayersPositions[p.PlayerIndex].y, 
//					0);
//				break;
//			default:
//				break;
//		}
		timerText.fontSize = 30;
		timerText.fontStyle = FontStyle.Bold;
	}
    
    public Util.Timer PlayerTimer
	{
		get
		{
			return playerTimer;
		}
	}

	////////////////////////////////////////////////////////

	public int PlayerIndex;
	
	public Vector2 Position;
	
	public Vector2 Size;

	////////////////////////////////////////////////////////

	Util.Timer playerTimer;

	GUIText timerText;
	
	Player player = null;

	Camera cam;

}
