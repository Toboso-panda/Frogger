using UnityEngine;

public class OffscreenDestroy : MonoBehaviour
{
    float leftLimit = -9.5f;
    float rightLimit = 9.5f;

    void Update()
    {
        // si la posició x surt del rang → Destroy(gameObject)
        if (transform.position.x < leftLimit || transform.position.x > rightLimit)
        {
            Destroy(gameObject);
        }
    }
}