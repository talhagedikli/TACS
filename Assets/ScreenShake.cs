using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Vector3 normalPosition;
    public Vector3 joltVector;

    public float joltDecayFactor;
    public float maxMoveSpeed;

    private void Awake() 
    {
        References.screenShake = this;
    }
    
    void Start()
    {
        normalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, normalPosition + joltVector, maxMoveSpeed * Time.deltaTime);
        joltVector *= joltDecayFactor;
    }
}
