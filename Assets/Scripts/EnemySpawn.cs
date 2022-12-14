using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyPrefab;
    public float secondsBetweenSpawns;
    private float secondsSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastSpawn = 0;
    }

    // Happens the same number of times for all players
    // So it's a good place for gameplay critical things
    private void FixedUpdate() 
    {
        secondsSinceLastSpawn += Time.fixedDeltaTime;
        if (secondsSinceLastSpawn >= secondsBetweenSpawns)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            secondsSinceLastSpawn = 0;
        } 
    }
}
