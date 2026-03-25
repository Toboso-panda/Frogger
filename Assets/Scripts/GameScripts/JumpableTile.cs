using UnityEngine;

public class JumpableTile : MonoBehaviour
{
    private Player playerOnTile;
    private Vector3 playerOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null)
        {
            //Debug.Log("Player entered the tile.");
            playerOnTile = player;
            
            player.toggleMovingPlatform(true);

            // Ensure we get the Movement component from the parent if not directly on the player
            Movement movement = this.GetComponent<Movement>();
            if (movement == null && this.transform.parent != null)
            {
                movement = this.transform.parent.GetComponent<Movement>();
            }

            if (movement != null)
            {
                player.gameObject.GetComponent<Movement>().speed = movement.speed;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>();

        if (player != null && player == playerOnTile)
        {
            //Debug.Log("Player exited the tile.");
            playerOnTile = null;
            player.toggleMovingPlatform(false);
            player.gameObject.GetComponent<Movement>().speed = 0;
        }
    }
}
