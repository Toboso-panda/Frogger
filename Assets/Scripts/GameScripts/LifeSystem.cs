using UnityEngine;


public class LifeSystem : MonoBehaviour
{
    int lives = 3;

    public void Update_lives(int amount)
    {
        lives += amount;
        Debug.Log("lives:" + lives);
        if (lives < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        GetComponent<SceneMng>().GoBackToMenu();
    }

    public int GetLives()
    {
        return lives;
    }

    public void SubstractLife()
    {
        Update_lives(-1);
    }
}
