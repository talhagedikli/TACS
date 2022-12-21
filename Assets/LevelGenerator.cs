using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> possibleChunkPrefabs;
    public List<GameObject> weponPrefabs;
    public GameObject antiquePrefab;

    public float fractionOfPlinthsToHaveAntiques;
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

        int numofThingsToPlace = References.plinths.Count;
        int numofAntiquesToPlace = Mathf.RoundToInt(numofThingsToPlace * fractionOfPlinthsToHaveAntiques);

        foreach (Plinth plinth in References.plinths)
        {
            GameObject thingToCreate;
            float chanceOfAntique = numofAntiquesToPlace / numofThingsToPlace;
            if (Random.value < chanceOfAntique)
            {
                // Place an antique
                thingToCreate = antiquePrefab;
                numofAntiquesToPlace--;
            }
            else
            {
                // Place a wepon
                // Pick a random type of thing 
                int randomThingIndex = Random.Range(0, weponPrefabs.Count);
                thingToCreate = weponPrefabs[randomThingIndex];
            }
            numofThingsToPlace--;
            
            // Instantiate one of those
            GameObject newThing = Instantiate(thingToCreate);

            // Assign it to this plinth
            plinth.AssignItem(newThing);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
