using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The general GUI manager
/// </summary>
public class GUIManager : MonoBehaviour, IInputListener
{

    // Use this for initialization
    void Start()
    {
        GlobalInput.RegisterListener(InputManager.InputCategory.GUI, this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////////////////////////////////////////////////////////

    public void AddItem(GUIItem item)
    {
        m_GUIElements.Add(item.AccessIndex, item);
    }

    ////////////////////////////////////////////////////////
	
	public void OnAxis(string axisName, float axisValue)
	{
		if (axisName == InputStringMapping.GUIInputMapping.NavigateHorizontal)
		{
			NavigateHorizontal(axisValue);
		}
		if (axisName == InputStringMapping.GUIInputMapping.NavigateVertical)
		{
			NavigateVertical(axisValue);
		}
	}

	public void OnMovement(string moveName, int x, int y)
	{

	}

    public void OnButtonUp(string button)
    {
        if (button == InputStringMapping.GUIInputMapping.Select)
        {
            Select();
        }
        if (button == InputStringMapping.GUIInputMapping.Back)
        {
            Back();
        }
        if (button == InputStringMapping.GUIInputMapping.Cancel)
        {
            Cancel();
        }
        if (button == InputStringMapping.GUIInputMapping.Pause)
        {
            Pause();
        }
    }

    public void OnButtonPressed(string button)
    {

    }

    public void OnButtonDown(string button)
    {

    }

    ////////////////////////////////////////////////////////

    private void NavigateHorizontal(float axis)
    {
		if (axis > 0.1f)
		{
			int nextIndex = Math.Abs(m_CurrentAccessIndex - 1) % m_GUIElements.Count;
			FocusIndex(nextIndex);
		}
		else if (axis < -0.1f)
		{
			int nextIndex = (m_CurrentAccessIndex + 1) % m_GUIElements.Count;
			FocusIndex(nextIndex);
		}
    }

	private void NavigateVertical(float axis)
    {
		// TODO
    }

    private void Select()
    {
        m_Focus = GetCurrentFocus();
        if (m_Focus != null)
        {
            m_Focus.OnSelect();
        }
    }

    private void Back()
    {
		// TODO
    }

    private void Pause()
    {
		// TODO
    }

    private void Cancel()
    {
		// TODO
    }

    ////////////////////////////////////////////////////////

    public void FocusIndex(int index)
    {
        // sanity check
        if (index < 0 || index > m_GUIElements.Count)
        {
            return;
        }

        m_CurrentAccessIndex = index;
        GUIItem lastFocus = m_Focus;
        m_Focus = GetCurrentFocus();

        if (lastFocus != null)
        {
            lastFocus.OnUnfocused();
        }

        if (m_Focus != null)
        {
            m_Focus.OnFocused();
        }
    }

    public GUIItem GetCurrentFocus()
    {
        m_Focus = null;
        if (m_GUIElements.TryGetValue(m_CurrentAccessIndex, out m_Focus))
        {
            return m_Focus;
        }
        return null;
    }

    ////////////////////////////////////////////////////////

    private int                                 m_CurrentAccessIndex = 0;

    private GUIItem                          m_Focus;

    private Dictionary<int, GUIItem>         m_GUIElements = new Dictionary<int, GUIItem>();

    ////////////////////////////////////////////////////////

    public InputManager                         GlobalInput;


}
