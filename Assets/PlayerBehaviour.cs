using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Never set the value of a public variable here - the inspector override it without telling you
    // If you need to, do it in Start() instead
    public float speed;
    public GameObject bulletPrefab;
    public float secondsBetweenShoots;

    private float secondsSinceLastShoot;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShoot = secondsBetweenShoots;
        References.thePlayer = this.gameObject;
    }

    // Update is called once per frame
    void Update() 
    {

        // Move player
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        ourRigidbody.velocity = inputVector * speed;


        // Where to new position to move to
        /* 
        float distanceToMove = speed * Time.deltaTime;
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movementVector = inputVector * distanceToMove;
        */

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        // Face the new position
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition);



        // Shoot bullet
        secondsSinceLastShoot += Time.deltaTime;

        if (secondsSinceLastShoot >= secondsBetweenShoots && Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
            secondsSinceLastShoot = 0;
        }
    }
}
