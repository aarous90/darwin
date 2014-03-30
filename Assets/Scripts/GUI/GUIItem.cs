using UnityEngine;
using System.Collections;

public class GUIItem : MonoBehaviour
{
	protected virtual void Init()
	{
		m_Element = gameObject.GetComponent(m_Name);
		GlobalGUI.AddItem(this);
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
        return m_Element;
    }

    ////////////////////////////////////////////////////////

    protected string        m_Name;         	/// The name of the gui element component
    private Component       m_Element;      	/// A reference to the Component itself
    public GUIManager       GlobalGUI;      	/// Field for the global GUIManager
    public int              AccessIndex = -1;    /// The index for navigaion with gamepad
}
