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
    public AudioSource audioSource;
    public float kickAmount;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShoot = secondsBetweenShoots;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the parameter, it will be set to 0 when we shoot
        secondsSinceLastShoot += Time.deltaTime;
    }

    public void Fire(Vector3 targetPosition)
    {
        if (secondsSinceLastShoot >= secondsBetweenShoots)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            // References.screenShake.joltVector = transform.forward * -1 * kickAmount; is removed
            // because we move camera, it looks like we are going forwards
            References.screenShake.joltVector = transform.forward * kickAmount;
            // Ready to fire
            References.alarmManager.SoundTheAlarm();
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                // Offset that target position by a random amount
                float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                Vector3 inaccuratePosition = targetPosition;
                // Target the position with some random values
                inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
                inaccuratePosition.z += Random.Range(-inaccuracy, inaccuracy);
                // Set the bullet's direction to new position
                newBullet.transform.LookAt(inaccuratePosition);
                // Set the dynamic parameter to 0
                secondsSinceLastShoot = 0;
            }
        }
    }

    public void BePickedUpByPlayer()
    {
            // Add it to player's internal list
            References.thePlayer.wepons.Add(this);
            // Move it to player location
            transform.position = References.thePlayer.transform.position;
            transform.rotation = References.thePlayer.transform.rotation;
            // Parent it to us, so it moves with us
            transform.SetParent(References.thePlayer.transform);
            // Select the currently picked wepon
            References.thePlayer.SelectLatestWepon();
        References.alarmManager.RaiseAlertLevel();
    }
}
