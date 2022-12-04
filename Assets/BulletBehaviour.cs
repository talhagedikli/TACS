using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        ourRigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // float distanceToMove = speed * Time.deltaTime;
        // transform.Translate(transform.forward * distanceToMove);
    }
}
