using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void MoveTo(Vector3 destination)
    {
        transform.position = destination;
    }
}
