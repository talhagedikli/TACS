using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBeam : BulletBehaviour
{
    public float maxDistanceToShoot;
    public LineRenderer myBeam;

    // Start is called before the first frame update
    void Start()
    {
        // Fire a laser to see how far we can go before we hit the wall
        // out RaycastHit hitInfo : define a variable to strore info about what happened when the ray hit something
        Physics.Raycast(transform.position, 
                        transform.forward, 
                        out RaycastHit hitInfo, 
                        References.maxDistanceInALevel, 
                        References.wallsLayer);
        float distanceToWall = hitInfo.distance;
        // Fire a new laser - only going to wall
        float beamThickness = 0.3f;
        RaycastHit[] listOfHitInfo = Physics.SphereCastAll(transform.position, beamThickness, transform.forward, maxDistanceToShoot, References.enemiesLayer);
        
        foreach (RaycastHit item in listOfHitInfo)
        {
            // We use parent because the hitted thing is just a collider
            HealthSystem enemyHealthSystem = item.collider.GetComponentInParent<HealthSystem>();
            if (enemyHealthSystem != null)
            {
                enemyHealthSystem.TakeDamage(damage);
            }
            
        }


        myBeam.SetPosition(0, transform.position);
        myBeam.SetPosition(1, hitInfo.point);

    }

    protected override void Update()
    {
        // This will handle thicking down our life timer, and killing us
        base.Update();
        myBeam.endColor = Color.Lerp(myBeam.endColor, Color.clear, 0.05f);
    }
}
