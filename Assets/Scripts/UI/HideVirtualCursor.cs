using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class HideVirtualCursor : MonoBehaviour
{
    [SerializeField] VirtualMouseInput _virtualMouse;

    public void SetCursorVisibility(bool isVisible)
    {
        if (_virtualMouse != null)
        {
            _virtualMouse.enabled = true;
        }
    }

}
