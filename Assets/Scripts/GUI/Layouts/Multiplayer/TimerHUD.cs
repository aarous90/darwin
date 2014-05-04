using UnityEngine;
using System.Collections;

public class TimerHUD : GUIItem
{

	// Use this for initialization
	protected override void Init()
	{
		timerText = GetComponent<GUIText>();
		playerTimer = new Util.Timer(-1, -1, true);
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

	public Util.Timer PlayerTimer
	{
		get
		{
			return playerTimer;
		}
	}

	////////////////////////////////////////////////////////

	Util.Timer playerTimer;

	GUIText timerText;


}
