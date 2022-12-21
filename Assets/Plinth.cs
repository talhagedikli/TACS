using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plinth : MonoBehaviour
{
    Useable myUseable;
    public TextMeshProUGUI myLabel;
    public Transform spotForItem;
    public GameObject cage;
    public float secondsToLock;

    private void OnEnable() 
    {
        References.plinths.Add(this);
    }
    private void OnDisable() 
    {
        References.plinths.Remove(this);
    }
    public void AssignItem(GameObject item)
    {
        myUseable = item.GetComponent<Useable>();
        myUseable.transform.position = spotForItem.transform.position;
        myUseable.transform.rotation = spotForItem.transform.rotation;
        myLabel.text = myUseable.displayName;
    }

    private void Update() {
        if (References.alarmManager.AlarmHasSounded() && secondsToLock > 0)
        {
            secondsToLock -= Time.deltaTime;
            if (secondsToLock <= 0)
            {
                cage.SetActive(true);
                myLabel.text = "ALARM";
                // If our object stil exist, and the player hasn't taken it yet
                if (myUseable != null && myLabel.enabled)
                {
                    Destroy(myUseable.gameObject);
                }
            }
        }
    }
}
