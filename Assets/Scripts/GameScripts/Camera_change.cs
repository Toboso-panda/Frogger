using UnityEngine;

public class Camera_change : MonoBehaviour
{
    public Vector3 camPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            CameraController cam = FindFirstObjectByType<CameraController>();
            cam.MoveTo(camPoint);
        }
    }

}
