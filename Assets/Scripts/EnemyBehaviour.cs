using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float visionRange;
    public float visionConeAngle;
    public bool alerted;
    private Rigidbody ourRigidbody;
    public Light myLight;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        alerted = false;
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
                // Follow the player
                ourRigidbody.velocity = vectorToPlayer.normalized * speed;
                Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
                transform.LookAt(playerPositionAtOurHeight);
                myLight.color = Color.red;
                
            }
            else
            {
                // Rotate
                Vector3 lateralOffset = transform.right * Time.deltaTime * turnSpeed;
                transform.LookAt(transform.position + transform.forward + lateralOffset);
                ourRigidbody.velocity = transform.forward * speed;
                // Check if we can see the player
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                    {
                        alerted = true;
                    }
                    
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
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

