using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        transform.position = mousePos;
    }
}
