using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    // ====== CONFIGURACIÓ ======
    
    [Header("Patró d’Spawn")]
    public GameObject[] prefabs;         // ordre del patró
    public float[] spawnIntervals;       // intervals corresponents

    public float[] movementSpeeds;       // velocitats de moviment dels objectes 
    public bool loopPattern = true;      // repetir el patró?

    [Header("Posició d’Spawn")]
    public Transform spawnPoint;         // punt on apareixen els objectes

    // ====== ESTAT INTERN ======
    
    private int index = 0;               // en quin punt del patró estem
    private float timer = 0f;            // comptador intern
    private bool patternActive = true;   // si el patró continua funcionant


    // ====== CICLE DE VIDA ======

    void Start()
    {
        InitializePattern();
    }

    void Update()
    {
        if (!patternActive) return;

        UpdateTimer();

        if (ShouldSpawn())
        {
            SpawnObject(prefabs[index]);
            AdvanceIndex();
            ResetTimer();
        }
    }


    // ====== FUNCIONS PRINCIPALS ======

    void InitializePattern()
    {
        // reinicia l’índex i el comptador
        index = 0;            
        ResetTimer();         
        patternActive = true;
    }

    void UpdateTimer()
    {
        // suma Time.deltaTime al timer
        timer += Time.deltaTime;
    }

    bool ShouldSpawn()
    {
        // retorna true si timer >= spawnIntervals[index]
        if (timer >= spawnIntervals[index])
        {
            return true;
        }
        return false;
    }

    void SpawnObject(GameObject prefab)
    {
        // instancia el prefab al spawnPoint
        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        
        // assigna la velocitat corresponent als components Movement dels fills
        Movement[] movementComponents = spawnedObject.GetComponentsInChildren<Movement>();
        foreach (Movement movement in movementComponents)
        {
            if (index < movementSpeeds.Length)
            {
                movement.speed = movementSpeeds[index];
            }
        }
    }

    void AdvanceIndex()
    {
        // incrementa index
        index++;
        // si arribem al final del patró:
        if (index == prefabs.Length)
        {
            // si loopPattern = true → index = 0
            // si no → patternActive = false
            if (loopPattern)
            {
                index = 0;
            }
            else 
            {
                patternActive = false;
            }
        }
    }

    void ResetTimer()
    {
        timer = 0f;
    }
}
