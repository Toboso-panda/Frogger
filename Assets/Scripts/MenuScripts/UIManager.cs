using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;

    void Update()
    {
        // Actualizar valores

        // Mostrar en pantalla
        scoreText.text = "Score: " + FindFirstObjectByType<Score>().GetScore();
        livesText.text = "Lives: " + FindFirstObjectByType<LifeSystem>().GetLives();
        timeText.text = "Time: " + Mathf.FloorToInt(FindFirstObjectByType<CountdownTimer>().GetTime());
    }
}