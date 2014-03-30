using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manages the input of the users
/// </summary>
public class InputManager : MonoBehaviour
{
	public enum InputCategory
	{
		GUI,
		Air,
		Ground,
		Water
	}

	public enum InputType
	{
		Button,
		Movement,
		Axis
	}

	public struct KeyCategory
	{
		public InputCategory Category;
		public string Name;
		public InputType Type;

		public KeyCategory(InputCategory category, InputType type, string name)
		{
			Category = category;
			Type = type;
			Name = name;
		}
	}

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

	public void RegisterListener(InputCategory category, IInputListener listener)
	{
		List<IInputListener> listenerList;

		if (m_CategoryInputListener.TryGetValue(category, out listenerList))
		{
			listenerList.Add(listener);
		}
		else
		{
			// TODO hans: handle errors

		}
	}

	public void RegisterListener(KeyCategory keyCategory, IInputListener listener)
	{
		List<IInputListener> listenerList;

		if (m_InputListener.TryGetValue(keyCategory, out listenerList))
		{
			listenerList.Add(listener);
		}
		else
		{
			// TODO hans: handle errors

		}
	}

	////////////////////////////////////////////////////////

	private void HandleInput()
	{
		foreach (KeyValuePair<KeyCategory, List<IInputListener>> entry in m_InputListener)
		{
			List<IInputListener> categoryListener;
			bool HasCategory = m_CategoryInputListener.TryGetValue(entry.Key.Category, out categoryListener) && (categoryListener.Count > 0);
			bool HasListener = (entry.Value.Count > 0) ? true : false;
			switch (entry.Key.Type)
			{
				case InputType.Axis:
					HandleAxisInput(HasListener, HasCategory, entry, categoryListener);
					break;
				case InputType.Button:
					HandleButtonInput(HasListener, HasCategory, entry, categoryListener);
					break;
				case InputType.Movement:
					break;
				default:
					break;
			}
		}
	}

	private void HandleButtonInput(bool HasListener, bool HasCategory, KeyValuePair<KeyCategory, List<IInputListener>> entry, List<IInputListener> categoryListener)
	{
		if ((HasListener || HasCategory) && Input.GetButtonUp(entry.Key.Name))
		{
			if (HasListener)
			{
				foreach (IInputListener l in entry.Value)
				{
					l.OnButtonUp(entry.Key.Name);

				}
			}

			if (HasCategory)
			{
				foreach (IInputListener l in categoryListener)
				{
					l.OnButtonUp(entry.Key.Name);
				}
			}
		}
		if ((HasListener || HasCategory) && Input.GetButton(entry.Key.Name))
		{
			if (HasListener)
			{
				foreach (IInputListener l in entry.Value)
				{
					l.OnButtonPressed(entry.Key.Name);
				}
			}

			if (HasCategory)
			{
				foreach (IInputListener l in categoryListener)
				{
					l.OnButtonPressed(entry.Key.Name);
				}
			}
		}
		if ((HasListener || HasCategory) && Input.GetButtonDown(entry.Key.Name))
		{
			if (HasListener)
			{
				foreach (IInputListener l in entry.Value)
				{
					l.OnButtonDown(entry.Key.Name);
				}
			}

			if (HasCategory)
			{
				foreach (IInputListener l in categoryListener)
				{
					l.OnButtonDown(entry.Key.Name);
				}
			}
		}
	}
	
	private void HandleAxisInput(bool HasListener, bool HasCategory, KeyValuePair<KeyCategory, List<IInputListener>> entry, List<IInputListener> categoryListener)
	{
		float axisValue = Input.GetAxis(entry.Key.Name);
		if ((HasListener || HasCategory) && axisValue > AxisThreshold)
		{
			if (HasListener)
			{
				foreach (IInputListener l in entry.Value)
				{
					l.OnAxis(entry.Key.Name, axisValue);

				}
			}

			if (HasCategory)
			{
				foreach (IInputListener l in categoryListener)
				{
					l.OnAxis(entry.Key.Name, axisValue);
				}
			}
		}
	}
	
	private void SetupInputHandler()
	{
		// create general listener dic for button names
		m_InputListener = new Dictionary<KeyCategory, List<IInputListener>>();

		// create category listener dic for the different layouts
		m_CategoryInputListener = new Dictionary<InputCategory, List<IInputListener>>();

		// create entries for the dic
		List<string> guiMappingStrings = InputStringMapping.GUIInputMapping.GetButtons();
		foreach (string mappingString in guiMappingStrings)
		{
			KeyCategory kc;
			kc.Name = mappingString;
			kc.Category = InputCategory.GUI;
			kc.Type = InputType.Button;
			m_InputListener.Add(kc, new List<IInputListener>());
		}
		guiMappingStrings = InputStringMapping.GUIInputMapping.GetAxis();
		foreach (string mappingString in guiMappingStrings)
		{
			KeyCategory kc;
			kc.Name = mappingString;
			kc.Category = InputCategory.GUI;
			kc.Type = InputType.Axis;
			m_InputListener.Add(kc, new List<IInputListener>());
		}

		m_CategoryInputListener.Add(InputCategory.GUI, new List<IInputListener>());
		m_CategoryInputListener.Add(InputCategory.Air, new List<IInputListener>());
		m_CategoryInputListener.Add(InputCategory.Ground, new List<IInputListener>());
		m_CategoryInputListener.Add(InputCategory.Water, new List<IInputListener>());

		// TODO hans: add the rest

	}

	////////////////////////////////////////////////////////

	private Dictionary<KeyCategory, List<IInputListener>> m_InputListener;

	private Dictionary<InputCategory, List<IInputListener>> m_CategoryInputListener;

	////////////////////////////////////////////////////////

	public float AxisThreshold;
}
