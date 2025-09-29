using UnityEngine;
using UnityEngine.Events;

public class MouseClickReader : MonoBehaviour
{
    private const int _mouseButton = 0;

    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Clicked?.Invoke();
        }
    }
}
