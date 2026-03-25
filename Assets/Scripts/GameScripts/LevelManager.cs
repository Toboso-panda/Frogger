using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public WinningTile[] slots;
    public void CheckWin()
    {
        foreach (WinningTile slot in slots)
        {
            if (!slot.GetReached())
            {
                return;
            }
        }
        // If we get here, all slots are reached, so we win
        Debug.Log("You win!");
        FindFirstObjectByType<Score>().AddBonusLivesScore();
        FindFirstObjectByType<SceneMng>().GoBackToMenu();
    }
}
