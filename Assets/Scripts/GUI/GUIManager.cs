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
			guiElements.Add(item.AccessIndex, item);
		}
    }

	public void RemoveItem(GUIItem item)
	{
		if (item.AccessIndex >= 0)
		{
			guiElements.Remove(item.AccessIndex);
		}
	}

	public void ClearGUI()
	{
		guiElements.Clear();
	}

    ////////////////////////////////////////////////////////
	
	public void OnAxis(string axisName, float axisValue)
	{
		if (Math.Abs(axisValue) > AxisMax && !maxAxis.ContainsKey(axisName))
		{
			maxAxis.Add(axisName, axisValue);
			return;
		}
		float value;
		if ((Math.Abs(axisValue) < AxisMax && maxAxis.TryGetValue(axisName, out value)))
		{
			if (axisName == InputStringMapping.GUIInputMapping.NavigateHorizontal)
			{
				NavigateHorizontal(value);
			}
			if (axisName == InputStringMapping.GUIInputMapping.NavigateVertical)
			{
				NavigateVertical(value);
			}
			maxAxis.Remove(axisName);
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
			FocusIndex(-1);
		}
		else if (axis < -AxisThreshold)
		{			
			FocusIndex(1);
		}
    }

    private void Select()
    {
        focus = GetCurrentFocus();
        if (focus != null)
        {
            focus.OnSelect();
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
			++currentAccessIndex;
			currentAccessIndex = currentAccessIndex % guiElements.Count;
		}
		else if (go < 0)
		{
			--currentAccessIndex;
			if (currentAccessIndex < 0)
			{
				currentAccessIndex = guiElements.Count - 1;
			}
			else
			{
				currentAccessIndex = (currentAccessIndex % guiElements.Count);
			}
		}
		else
		{
			currentAccessIndex = 0;
		}

        GUIItem lastFocus = focus;
        focus = GetCurrentFocus();

        if (lastFocus != null)
        {
            lastFocus.OnUnfocused();
        }

        if (focus != null)
        {
            focus.OnFocused();
        }
    }

    public GUIItem GetCurrentFocus()
    {
        focus = null;
        if (guiElements.TryGetValue(currentAccessIndex, out focus))
        {
            return focus;
        }
        return null;
    }

    ////////////////////////////////////////////////////////

    public InputManager						GlobalInput;
	public float							AxisThreshold = 0.1f;
	public float							AxisMax = 0.9f;

	////////////////////////////////////////////////////////
	
	private int                             currentAccessIndex = 0;
	
	private GUIItem                         focus;
	
	private Dictionary<int, GUIItem>        guiElements = new Dictionary<int, GUIItem>();
	
	private Dictionary<string, float>		maxAxis = new Dictionary<string, float>();

}
