using UnityEngine;

public class Button : GUIItem 
{
	protected override void Init()
	{
		buttonTexture = GetComponent<GUITexture>();
		selected = (Texture2D) buttonTexture.texture;
		elementName = this.GetType().Name;
		buttonTexture.texture = Unfocused;
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
		guiTexture.texture = selected;
	}

    ////////////////////////////////////////////////////////
    
    public Texture2D Focused;
	public Texture2D Unfocused;

    ////////////////////////////////////////////////////////

	protected GUITexture buttonTexture;

    bool isHovered;

    bool isDown;

	bool isUp;

	Texture2D selected;
}
