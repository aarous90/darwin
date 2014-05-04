using UnityEngine;
using System.Collections;

public class GUIItem : MonoBehaviour
{
	protected virtual void Init()
	{
		Element = gameObject.GetComponent(ElementName);
		GUIManager.Get().AddItem(this);
	}

    // Use this for initialization
	protected virtual void Start()
    {
		Init();
    }
	
	// Update is called once per frame
	void Update() 
    {

	}

    ////////////////////////////////////////////////////////

    public virtual void OnSelect()
    { 
    
    }

	public virtual void OnBack()
	{

	}

	public virtual void OnCancel()
	{

	}

	public virtual void OnPause()
	{

	}

	public virtual void OnFocused()
    { 
        
    }

	public virtual void OnUnfocused()
    { 
        
    }

    ////////////////////////////////////////////////////////

    /// <summary>
    /// get the main component named by m_Name.
    /// You have to set this name like:
    ///         m_Name = "Button";
    ///         base.Start();
    /// In you Start() method!
    /// </summary>
    /// <returns></returns>
    public Component GetElement()
    {
        return Element;
    }

    ////////////////////////////////////////////////////////

	/// <summary>
	/// The name of the gui element component.
	/// </summary>
    protected string        	ElementName;
    
	/// <summary>
	/// A reference to the Component itself.
	/// </summary>
	protected Component       	Element;

	/// <summary>
	/// The index for navigaion with gamepad.
	/// </summary>
    public int					AccessIndex = -1;    	
}
