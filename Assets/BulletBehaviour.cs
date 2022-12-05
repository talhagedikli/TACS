using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float secondsUntilDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        ourRigidbody.velocity = transform.forward * speed;
        // Debug.Log("rotation: " + transform.rotation.ToString());
        // Debug.Log("forward: " + transform.forward.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // float distanceToMove = speed * Time.deltaTime;
        // transform.Translate(transform.forward * distanceToMove);
        secondsUntilDestroyed -= Time.deltaTime;
        

        transform.localScale *= (Mathf.Clamp(secondsUntilDestroyed,0,1));

        if (secondsUntilDestroyed < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        GameObject theirGameObject = other.gameObject;

        if (theirGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            Destroy(gameObject);
            Destroy(theirGameObject);
        }
    }

    

}
