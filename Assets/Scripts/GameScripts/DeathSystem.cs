using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    public void Death()
    {
        Player player = FindFirstObjectByType<Player>();
        SoundManager.PlaySound(SoundType.Death);
        player.Respawn();
        LifeSystem life = FindFirstObjectByType<LifeSystem>();
        life.SubstractLife();
        CountdownTimer timer = FindFirstObjectByType<CountdownTimer>();
        timer.ResetTimer();

    }
}
