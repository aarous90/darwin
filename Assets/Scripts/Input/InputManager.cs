using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manages the input of the users
/// </summary>
public class InputManager : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
    {
        SetupInputHandler();
	}
	
	// Update is called once per frame
	void Update() 
    {
        HandleInput();
	}

    ////////////////////////////////////////////////////////

    /// <summary>
    /// 
    /// </summary>
    /// <param name="button"></param>
    /// <param name="listener"></param>
    public void RegisterListener(string button, IInputListener listener)
    {
        List<IInputListener> listenerList;

        if (m_InputListenerDictionary.TryGetValue(button, out listenerList))
        {
            listenerList.Add(listener);
        }
        else
        {
            // TODO hans: handle errors

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="button"></param>
    /// <param name="listener"></param>
    public void UnregisterListener(string button, IInputListener listener)
    {
        List<IInputListener> listenerList;

        if (m_InputListenerDictionary.TryGetValue(button, out listenerList))
        {
            listenerList.Remove(listener);
        }
        else
        {
            // TODO hans: handle errors

        }
    }

    ////////////////////////////////////////////////////////

    private void HandleInput()
    {
        foreach (KeyValuePair<string, List<IInputListener>> entry in m_InputListenerDictionary)
        {
            if (Input.GetButtonUp(entry.Key))
            {
                foreach (IInputListener l in entry.Value)
                {
                    l.OnButtonUp(entry.Key);
                }
            }
            if (Input.GetButton(entry.Key))
            {
                foreach (IInputListener l in entry.Value)
                {
                    l.OnButtonPressed(entry.Key);
                }
            }
            if (Input.GetButtonDown(entry.Key))
            {
                foreach (IInputListener l in entry.Value)
                {
                    l.OnButtonDown(entry.Key);
                }
            }
        }
    }

    private void SetupInputHandler()
    {
        m_InputListenerDictionary =
            new Dictionary<string, List<IInputListener>>();

        // create entries for the dic
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.Back, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.Select, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.Cancel, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.NavigateDown, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.NavigateLeft, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.NavigateRight, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.NavigateUp, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.Pause, new List<IInputListener>());
        m_InputListenerDictionary.Add(InputStringMapping.GUIInputMapping.Select, new List<IInputListener>());

        // TODO hans: add the rest

    }

    ////////////////////////////////////////////////////////

    private Dictionary<string, List<IInputListener>> m_InputListenerDictionary;
}
