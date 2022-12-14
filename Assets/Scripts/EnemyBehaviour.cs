using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float speed;
    public Rigidbody ourRigidbody;

    /* This is our parent class for all enemises */

    // Protected: this function can bu used by our children and us, but no-one else
    // We probably don't want anything to be 'private'
    // Virtual: this can be over-written by our children - bbug if they don^t override it, they just use our version
    // Void: this is what the function returns - in this case 'nothing'
    protected virtual void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ChasePlayer();
    }

    // protected: your child can use it to
    protected void ChasePlayer()
    {
        // The eye which looks is negative
        // Seek the player
        if (References.thePlayer != null) 
        {
            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;

            // Follow the player
            ourRigidbody.velocity = vectorToPlayer.normalized * speed;
            Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(playerPositionAtOurHeight);
        }
    }

    protected void OnCollisionEnter(Collision other) 
    {
        GameObject theirGameObject = other.gameObject;

        if (theirGameObject.GetComponent<PlayerBehaviour>() != null)
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem != null)
            {
                theirHealthSystem.TakeDamage(1);
            }
        }
    }
}

