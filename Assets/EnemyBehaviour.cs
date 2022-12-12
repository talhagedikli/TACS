using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The eye which looks is negative
        if (References.thePlayer != null)
        {
            Rigidbody ourRigidbody = GetComponent<Rigidbody>();
            Vector3 vectorToPlayer = References.thePlayer.transform.position - transform.position;
            ourRigidbody.velocity = vectorToPlayer.normalized * speed;
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

