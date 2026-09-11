using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float offset = -10f;
    void Start()
    {
        
    }

    void Update()
    {
       transform.position = new Vector3(target.transform.position.x, target.transform.position.y,offset);
    }
}
