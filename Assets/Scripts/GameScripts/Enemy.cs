using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player == null){
            return;
        }

        FindFirstObjectByType<DeathSystem>().Death();
    }
}
