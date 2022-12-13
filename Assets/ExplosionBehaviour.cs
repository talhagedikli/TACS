using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float secondsToExist;
    private float secondsWeveBeenAlive;
    private Vector3 maxScale = Vector3.one * 5;
    // Start is called before the first frame update
    void Start()
    {
        secondsWeveBeenAlive = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        secondsWeveBeenAlive += Time.fixedDeltaTime;

        float lifeFraction = secondsWeveBeenAlive / secondsToExist;
        transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, lifeFraction);

        if (secondsWeveBeenAlive >= secondsToExist)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        // Look for the health system the thing we collided
        HealthSystem theirHealthSystem = other.gameObject.GetComponent<HealthSystem>();
        if (theirHealthSystem != null)
        {
            // If we found take damage
            theirHealthSystem.TakeDamage(10);
        }    
    }
}
