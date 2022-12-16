using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    public float speed;
    public Rigidbody ourRigidbody;
    public NavMeshAgent navAgent;

    /* This is our parent class for all enemises */

    // Protected: this function can bu used by our children and us, but no-one else
    // We probably don't want anything to be 'private'
    // Virtual: this can be over-written by our children - bbug if they don^t override it, they just use our version
    // Void: this is what the function returns - in this case 'nothing'
    // Make them protected to use it within it's children (for example guards)
    protected void OnEnable() 
    {
        References.allEnemies.Add(this);
    }
    protected void OnDisable() 
    {
        References.allEnemies.Remove(this);
    }

    protected virtual void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
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
            navAgent.destination = playerPosition;

            // Follow the player
            /*
            ourRigidbody.velocity = vectorToPlayer.normalized * speed;
            Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(playerPositionAtOurHeight);
            */
        }
    }


}

