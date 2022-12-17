using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Useable : MonoBehaviour
{
    public UnityEvent whenUsed;
    public bool canBeReused;

    public void Use()
    {
        whenUsed.Invoke();
        if (canBeReused == false)
        {
            enabled = false;
        }
    }


    private void OnEnable() 
    {
        References.usables.Add(this);    
    }

    private void OnDisable() 
    {
        References.usables.Remove(this);    
    }


}
