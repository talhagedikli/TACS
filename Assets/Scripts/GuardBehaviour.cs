using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : EnemyBehaviour
{
    public float visionRange;
    public float visionConeAngle;
    public bool alerted;
    public Light myLight;
    public float turnSpeed;

    /* This is specifically guard behaviour, child of the enemy */

    // Protected: we have to give it the same 'axcess' type as wwe did in the parent
    // Override: we know our parent has a version of this function, and we are deciding to override it - use our version instead
    // base.Start(): run our parent's version of this
    protected override void Start()
    {
        base.Start();
        alerted = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // The eye which looks is negative
        // Seek the player
        if (References.thePlayer != null)
        {
            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            myLight.color = Color.white;

            if (alerted)
            {
                myLight.color = Color.red;
                ChasePlayer();
            }
            else
            {
                // Rotate
                Vector3 lateralOffset = transform.right * Time.deltaTime * turnSpeed;
                transform.LookAt(transform.position + transform.forward + lateralOffset);
                // ourRigidbody.velocity = transform.forward * speed;
                // Check if we can see the player
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                    {
                        // Returns true if we hit something on that layer
                        if (Physics.Raycast(transform.position, vectorToPlayer, vectorToPlayer.magnitude, References.wallsLayer) == false)
                        {
                            // First time we see the player
                            alerted = true;
                            References.spawner.activated = true;
                        }
                    }
                    
                }
            }
        }
    }
}

