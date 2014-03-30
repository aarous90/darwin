using UnityEngine;

public class Button : GUIItem 
{
	protected override void Init()
	{
		m_ButtonTexture = GetComponent<GUITexture>();
		Selected = (Texture2D) m_ButtonTexture.texture;
		m_Name = this.GetType().Name;
		m_ButtonTexture.texture = Unfocused;
        base.Init();
	}
	
	// Update is called once per frame
	void Update() 
    {

	}

	public override void OnFocused()
	{
		guiTexture.texture = Focused;
	}

	public override void OnUnfocused()
	{
		guiTexture.texture = Unfocused;
	}

	public override void OnSelect()
	{
		guiTexture.texture = Selected;
	}

    ////////////////////////////////////////////////////////
    
    public Texture2D Focused;
	public Texture2D Unfocused;
	private Texture2D Selected;

    ////////////////////////////////////////////////////////

	protected GUITexture m_ButtonTexture;

    private bool m_IsHovered;

    private bool m_IsDown;

	private bool m_IsUp;
}
