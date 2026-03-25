using UnityEngine;

public class SpawnBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.transform.position = new Vector3(player.transform.position.x, 0.5f, player.transform.position.z); // Move the player up by 1 unit
        }
    }
}
