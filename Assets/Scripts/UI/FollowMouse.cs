using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            transform.position = mousePos;
        }
    }
}
