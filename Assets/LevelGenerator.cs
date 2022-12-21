using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> possibleChunkPrefabs;
    public List<GameObject> thingsToPutOnPlinths;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 3; i++)
        {
            // Get a random chunk type
            int randomChunkIndex = Random.Range(0, possibleChunkPrefabs.Count);
            GameObject randomChunkType = possibleChunkPrefabs[randomChunkIndex];
            Vector3 spawnPosition = transform.position + new Vector3(i * 15, 0, 0);
            // Quaternion.identity is default rotation
            Instantiate(randomChunkType, spawnPosition, Quaternion.identity);
            possibleChunkPrefabs.Remove(randomChunkType);

        }

        foreach (Plinth plinth in References.plinths)
        {
            // Pick a random type of thing 
            int randomThingIndex = Random.Range(0, thingsToPutOnPlinths.Count);
            GameObject randomThingType = thingsToPutOnPlinths[randomThingIndex];
            // Instantiate one of these
            GameObject newThing = Instantiate(randomThingType);
            // Assign it to the plinth
            plinth.AssignItem(newThing);
            // thingsToPutOnPlinths.Remove(randomThingType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
