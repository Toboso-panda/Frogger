using UnityEngine;

public class DeathTile : MonoBehaviour
{
    private Player playerInWater;
    private bool deathTriggered;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null)
        {
            playerInWater = player;
            deathTriggered = false;
            //Debug.Log("Player entered water.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null && player == playerInWater)
        {
            playerInWater = null;
            deathTriggered = false;
            //Debug.Log("Player exited water.");
        }
    }

    void Update()
    {
        if (playerInWater == null || deathTriggered)
        {
            return;
        }

        if (playerInWater.IsOnMovingPlatform())
        {
            return;
        }

        DeathSystem deathSystem = FindFirstObjectByType<DeathSystem>();
        if (deathSystem == null)
        {
            return;
        }

        deathTriggered = true;
        Debug.Log("Killed in water");
        deathSystem.Death();
        playerInWater = null;
    }
}
