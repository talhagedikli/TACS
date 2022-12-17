using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Never set the value of a public variable here - the inspector override it without telling you
    // If you need to, do it in Start() instead
    public float speed;
    public List<WeponBehaviour> wepons = new List<WeponBehaviour>();
    public int selectedWeponIndex;
    private Rigidbody ourRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        References.thePlayer = this;
        ourRigidbody = GetComponent<Rigidbody>();
        selectedWeponIndex = 0;
    }

    // Update is called once per frame
    void Update() 
    {

        // Move player
        // Rigidbody ourRigidbody = GetComponent<Rigidbody>(); Inıt in start()
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        ourRigidbody.velocity = inputVector * speed;

        // Get cursor position in 3d world
        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        // Face the new position
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition);

        // Fire with gun
        if (Input.GetButton("Fire1") && wepons.Count > 0)
        {
            WeponBehaviour currentWepon = wepons[selectedWeponIndex];
            // Tell our wepon to fire
            currentWepon.Fire(cursorPosition);
        }
        // Switch between guns
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeWeponIndex(selectedWeponIndex + 1);

        }

        if (Input.GetButtonDown("Use"))
        {
            // Use the nearest useable
            Useable nearestUseable = null;
            // Set the max range
            float nearestDistance = 2;
            foreach (Useable useable in References.usables)
            {
                // How far is this one from the player?
                float distance = Vector3.Distance(transform.position, useable.transform.position);
                // If that closer than anything else we've found?
                if (distance <= nearestDistance)
                {
                    // It is - remember that this is now the closest one we've found
                    nearestUseable = useable;
                    nearestDistance = distance;
                }
            }

            if (nearestUseable != null)
            {
                nearestUseable.Use();
            }
        }
    }

    public void SelectLatestWepon()
    {
        ChangeWeponIndex(wepons.Count - 1);
    }

    private void ChangeWeponIndex(int index)
    {
        // Change index
        selectedWeponIndex = index;
        // If it's gone too far, loop back
        if (selectedWeponIndex >= wepons.Count)
        {
            selectedWeponIndex = 0;
        }

        // For each wepon in our list
        for (int i = 0; i < wepons.Count; i++)
        {
            WeponBehaviour iThWepon = wepons[i];
            if (i == selectedWeponIndex)
            {
                // If it's the one we just selected, make it visible - enable it
                iThWepon.gameObject.SetActive(true);
            }
            else
            {
                // If it's not, disable it
                iThWepon.gameObject.SetActive(false);
            }
        }
    }

    // Pick up a wepon
    private void OnTriggerEnter(Collider other) 
    {
        // WeponBehaviour theirWepon = other.GetComponentInParent<WeponBehaviour>();
        // if (theirWepon != null)
        // {
        //     // Add it to our internal list
        //     wepons.Add(theirWepon);
        //     // Move it to our location
        //     theirWepon.transform.position = transform.position;
        //     theirWepon.transform.rotation = transform.rotation;
        //     // Parent it to us, so it moves with us
        //     theirWepon.transform.SetParent(transform);
        //     // Select the currently picked wepon
        //     ChangeWeponIndex(wepons.Count - 1);
        // }
    }
}
