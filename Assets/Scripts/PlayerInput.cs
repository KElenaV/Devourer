using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _mousePosition;

    public Vector2 MousePosition => _mousePosition;

    private void Update()
    {
        _mousePosition = Input.mousePosition;
    }
}
