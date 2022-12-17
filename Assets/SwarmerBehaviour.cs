using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehaviour : EnemyBehaviour
{

    public GameObject explosionPrefab;

    protected void OnCollisionEnter(Collision other) 
    {
        GameObject theirGameObject = other.gameObject;

        if (theirGameObject == References.thePlayer.gameObject)
        {
            // Create an explosion - this will hurt the player
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy ourselves
            Destroy(gameObject);
        }
    }
}
