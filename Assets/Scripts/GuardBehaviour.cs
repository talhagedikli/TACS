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
    public WeponBehaviour myWepon;
    public float reactionTime;
    float secondsSeeingPlayer;
    /* This is specifically guard behaviour, child of the enemy */

    // Protected: we have to give it the same 'axcess' type as wwe did in the parent
    // Override: we know our parent has a version of this function, and we are deciding to override it - use our version instead
    // base.Start(): run our parent's version of this
    protected override void Start()
    {
        base.Start();
        alerted = false;

        GoToRandomNavPoint();
        secondsSeeingPlayer = 0;

    }

    protected Vector3 PlayerPosition()
    {
        return References.thePlayer.transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (References.levelManager.alarmSounded)
        {
            alerted = true;
        }
        // The eye which looks is negative
        // Seek the player
        if (References.thePlayer != null)
        {
            Vector3 vectorToPlayer = PlayerPosition() - transform.position;
            myLight.color = Color.white;

            if (alerted)
            {
                myLight.color = Color.red;
                ChasePlayer();
                PlayerBehaviour playerRef = References.thePlayer;
                if (CanSeePlayer()) 
                {
                    secondsSeeingPlayer += Time.deltaTime;
                    // Look at the player before shooting
                    transform.LookAt(PlayerPosition());
                    if (secondsSeeingPlayer >= reactionTime)
                    {
                        myWepon.Fire(PlayerPosition());
                    }
                }
                else
                {
                    // Not seeing player
                    secondsSeeingPlayer = 0;
                }
            }
            else
            {
                if (navAgent.remainingDistance < 0.5f)
                {
                    GoToRandomNavPoint();
                }
                // ourRigidbody.velocity = transform.forward * speed;
                // Check if we can see the player
                if (Vector3.Distance(transform.position, PlayerPosition()) <= visionRange)
                {
                    if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                    {
                        // Returns true if we hit something on that layer
                        if (Physics.Raycast(transform.position, vectorToPlayer, vectorToPlayer.magnitude, References.wallsLayer) == false)
                        {
                            // First time we see the player
                            alerted = true;
                            References.levelManager.alarmSounded = true;
                        }
                    }
                    
                }
            }
        }
    }
    void GoToRandomNavPoint()
    {
        // When we give Random.Range float numbers, they can go all the way up to the max
        // But when we give integers, it will never choose the max
        int randomNavPointIndex = Random.Range(0, References.navPoints.Count);
        navAgent.destination = References.navPoints[randomNavPointIndex].transform.position;
    }

    protected bool CanSeePlayer()
    {
        PlayerBehaviour player = References.thePlayer;
        if (player == null)
        {
            return false;
        }
        Vector3 vectorToPlayer = PlayerPosition() - transform.position;
        // Just for seeing or not player
        bool hitTheWall = Physics.Raycast(transform.position, 
                        transform.forward, 
                        vectorToPlayer.magnitude, 
                        References.wallsLayer
        );
        if (hitTheWall)
        {
            // The ray hit the wall BEFORE reach the player
            return false;
        }
        else
        {
            // The ray hit no walls before it reached player
            return true;
        }
    }

    public void KnockoutAttempt()
    {
        if (References.levelManager.alarmSounded == false)
        {
            HealthSystem myHealthSystem = GetComponent<HealthSystem>();
            myHealthSystem.KillMe();
        }
    }
}

