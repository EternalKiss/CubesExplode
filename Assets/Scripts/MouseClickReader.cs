using UnityEngine;
using System;
using UnityEngine.Events;

public class MouseClickReader : MonoBehaviour
{
    private const int _mouseButton = 0;

    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Clicked?.Invoke();
        }
    }
}
