using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;  
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        // The eye which looks is negative
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        ourRigidbody.velocity = vectorToPlayer.normalized * speed;
        // ourRigidbody.velocity = Vector3 towards the 'player'
    }
}
