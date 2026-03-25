using UnityEngine;

public class WinningTile : MonoBehaviour
{
    bool reached = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            //Debug.Log("Player entered the tile.");
            player.Win();
            reached = true;

            // Sumar els punts corresponents
            Score score = FindFirstObjectByType<Score>();
            score.AddBonusTimeScore();

            // Reininiar el temps
            FindFirstObjectByType<CountdownTimer>().ResetTimer();

            LevelManager lm = GetComponentInParent<LevelManager>();
            lm.CheckWin();
            enabled = false; // desactiva WinningTile
            GetComponent<Collider2D>().enabled = false;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = Color.red;

        }
    }

    public bool GetReached()
    {
        return reached;
    }
}
