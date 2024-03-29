using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float secondsUntilDestroyed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        ourRigidbody.velocity = transform.forward * speed;
        // Debug.Log("rotation: " + transform.rotation.ToString());
        // Debug.Log("forward: " + transform.forward.ToString());
    }

    // Update is called once per frame
    protected virtual void Update()
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
        HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
        if (theirHealthSystem != null)
        {
            theirHealthSystem.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    

}
