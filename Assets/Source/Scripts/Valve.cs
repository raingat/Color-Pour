using System;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public event Action Pressed;

    public void Press()
    {
        Pressed?.Invoke();
    }
}
