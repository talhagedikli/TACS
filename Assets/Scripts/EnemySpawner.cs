using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyPrefab;
    public float secondsBetweenSpawns;
    private float secondsSinceLastSpawn;

    public int enemiesToSpawn;

    private void OnEnable() 
    {
        References.spawners.Add(this);    
    }

    private void OnDisable() 
    {
        References.spawners.Remove(this);    
    }

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastSpawn = 0;
    }

    // Happens the same number of times for all players
    // So it's a good place for gameplay critical things
    private void FixedUpdate() 
    {
        if (References.levelManager.alarmSounded && enemiesToSpawn > 0)
        {
            secondsSinceLastSpawn += Time.fixedDeltaTime;
            if (secondsSinceLastSpawn >= secondsBetweenSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                secondsSinceLastSpawn = 0;
                enemiesToSpawn -= 1;
            }
        } 
    }
}
