using UnityEngine;
public class CountdownTimer : MonoBehaviour
{
    float totalTime = 60; 
   
    public void ResetTimer()
    {
        totalTime = 60;
    }

    void Update()
    {
        if (totalTime > 0)
        {
            // Decrease the timer by the time elapsed since the last frame
            totalTime -= Time.deltaTime;
        }
        else
        {
            // Timer has reached zero
            totalTime = 0;
            GetComponent<DeathSystem>().Death();
            
        }
    }

    public float GetTime()
    {
        return totalTime;
    }
}