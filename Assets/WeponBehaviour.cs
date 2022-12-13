using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponBehaviour : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float accuracy;
    public float secondsBetweenShoots;
    private float secondsSinceLastShoot;
    public float numberOfProjectiles;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShoot = secondsBetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot bullet
        secondsSinceLastShoot += Time.deltaTime;

   
    }

    public void Fire(Vector3 targetPosition)
    {
        if (secondsSinceLastShoot >= secondsBetweenShoots)
        {
            // Ready to fire
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                // Offset that target position by a random amount
                float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                targetPosition.x += Random.Range(-inaccuracy, inaccuracy);
                targetPosition.z += Random.Range(-inaccuracy, inaccuracy);
                newBullet.transform.LookAt(targetPosition);
                secondsSinceLastShoot = 0;
                newBullet.name = i.ToString();
            }
        }
    }
}
