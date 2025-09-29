using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private MouseClickReader _mouseClickInput;
    [SerializeField] private float _maxDistance;

    public event Action<Cube> Hited;

    private void OnEnable()
    {
        _mouseClickInput.Clicked += HandleInput;
    }

    private void OnDisable()
    {
        _mouseClickInput.Clicked -= HandleInput;
    }

    private void HandleInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                Hited?.Invoke(cube);
            }
        }
    }
}
