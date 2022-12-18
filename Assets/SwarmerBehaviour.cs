using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehaviour : EnemyBehaviour
{

    public GameObject explosionPrefab;

    protected void OnCollisionEnter(Collision other) 
    {
        GameObject theirGameObject = other.gameObject;
        PlayerBehaviour possiblePlayer = theirGameObject.GetComponent<PlayerBehaviour>();


        if (possiblePlayer == References.thePlayer)
        {
            // Create an explosion - this will hurt the player
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            // Destroy ourselves
            Destroy(gameObject);
        }
    }
}
