using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The general GUI manager
/// </summary>
public class GUIManager : MonoBehaviour, IInputListener
{
	public static GUIManager Get()
	{
		GameObject im = GameObject.Find("GUIManager");
		if (im != null)
		{
			return im.GetComponent<GUIManager>();
		}
		return null;
	}

    // Use this for initialization
    void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		GlobalInput.RegisterListener(InputManager.InputCategory.GUI, this);
		FocusIndex(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////////////////////////////////////////////////////////

    public void AddItem(GUIItem item)
    {
		if (item.AccessIndex >= 0)
		{
			m_GUIElements.Add(item.AccessIndex, item);
		}
    }

	public void RemoveItem(GUIItem item)
	{
		if (item.AccessIndex >= 0)
		{
			m_GUIElements.Remove(item.AccessIndex);
		}
	}

    ////////////////////////////////////////////////////////
	
	public void OnAxis(string axisName, float axisValue)
	{
		if (Math.Abs(axisValue) > AxisMax && !m_MaxAxis.ContainsKey(axisName))
		{
			m_MaxAxis.Add(axisName, axisValue);
			return;
		}
		float value;
		if ((Math.Abs(axisValue) < AxisMax && m_MaxAxis.TryGetValue(axisName, out value)))
		{
			if (axisName == InputStringMapping.GUIInputMapping.NavigateHorizontal)
			{
				NavigateHorizontal(value);
			}
			if (axisName == InputStringMapping.GUIInputMapping.NavigateVertical)
			{
				NavigateVertical(value);
			}
			m_MaxAxis.Remove(axisName);
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
		// TODO
    }

	private void NavigateVertical(float axis)
    {
		if (axis > AxisThreshold)
		{
			FocusIndex(1);
		}
		else if (axis < -AxisThreshold)
		{			
			FocusIndex(-1);
		}
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

    public void FocusIndex(int go)
    {
		if (go > 0)
		{
			++m_CurrentAccessIndex;
			m_CurrentAccessIndex = m_CurrentAccessIndex % m_GUIElements.Count;
		}
		else if (go < 0)
		{
			--m_CurrentAccessIndex;
			if (m_CurrentAccessIndex < 0)
			{
				m_CurrentAccessIndex = m_GUIElements.Count - 1;
			}
			else
			{
				m_CurrentAccessIndex = (m_CurrentAccessIndex % m_GUIElements.Count);
			}
		}
		else
		{
			m_CurrentAccessIndex = 0;
		}

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

    private int                             m_CurrentAccessIndex = 0;

    private GUIItem                         m_Focus;

    private Dictionary<int, GUIItem>        m_GUIElements = new Dictionary<int, GUIItem>();

	private Dictionary<string, float>		m_MaxAxis = new Dictionary<string, float>();

    ////////////////////////////////////////////////////////

    public InputManager						GlobalInput;
	public float							AxisThreshold = 0.1f;
	public float							AxisMax = 0.9f;


}
