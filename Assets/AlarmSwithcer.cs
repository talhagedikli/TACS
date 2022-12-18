using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSwithcer : MonoBehaviour
{
    public GameObject unalarmedObject;
    public GameObject alarmedObject;
    // Update is called once per frame
    void Update()
    {
        if (unalarmedObject.activeInHierarchy && References.alarmManager.AlarmHasSounded())
        {
            // If we want to just activate or deactivate, we should get their gameObjects
            unalarmedObject.SetActive(false);
            alarmedObject.SetActive(true);
        }
    }
}
