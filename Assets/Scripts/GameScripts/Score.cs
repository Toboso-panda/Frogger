using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;
    int baseScore = 10;
    int baseLifeScore = 500;
    int timeScoreMultiplier = 10;
    int WinningTileScore = 100;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        if (score < 0) score = 0;
        Debug.Log("Score: " + score); 
    }

    public int GetScore()
    {
        return score;
    }

    public int GetBaseScore()
    {
        return baseScore;
    }


    public void ResetBaseScore()
    {
        baseScore = 10;
    }

    public void AddBonusLivesScore()
    {
        LifeSystem lf = GetComponent<LifeSystem>();
        score += lf.GetLives() * baseLifeScore;
    }

    public void AddBonusTimeScore()
    {  
        CountdownTimer clock = GetComponent<CountdownTimer>();     
        score += Mathf.FloorToInt(clock.GetTime()) * timeScoreMultiplier;
    }

    public void AddWinningTileScore()
    {
        score += WinningTileScore;
    }

    

}
