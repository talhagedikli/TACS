using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plinth : MonoBehaviour
{
    Useable myUseable;
    public TextMeshProUGUI myLabel;
    public Transform spotForItem;

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
}
