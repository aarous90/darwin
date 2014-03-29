using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Implement this if you are using input
/// </summary>
public interface IInputListener
{
    void OnButtonUp(string button);
    void OnButtonPressed(string button);
    void OnButtonDown(string button);
}
