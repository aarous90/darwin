using UnityEngine; using System.Collections;  public class GUIElement : MonoBehaviour, IInputListener {      // Use this for initialization     protected void Start()     {         m_Element = gameObject.GetComponent(m_Name);     } 	 	// Update is called once per frame 	void Update()      {  	}      ////////////////////////////////////////////////////////

    public void OnButtonUp(string button)
    {

    }

    public void OnButtonPressed(string button)
    {

    }

    public void OnButtonDown(string button)
    {

    }      ////////////////////////////////////////////////////////      /// <summary>     /// get the main component named by m_Name.     /// You have to set this name like:     ///         m_Name = "Button";     ///         base.Start();     /// In you Start() method!     /// </summary>     /// <returns></returns>     public Component GetElement()     {         return m_Element;     }      ////////////////////////////////////////////////////////      protected string      m_Name;      private Component   m_Element;
} 