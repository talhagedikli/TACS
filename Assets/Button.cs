using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    RectTransform rectangle;
    Image image;

    public UnityEvent eventToTrigger;

    public SceneAsset firstScene;

    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the mouse is within our rectangle
        if (RectTransformUtility.RectangleContainsScreenPoint(rectangle, Input.mousePosition))
        {
            image.color = Color.black;

            // Clicking should do something 
            if (Input.GetButtonDown("Fire1"))
            {
                eventToTrigger.Invoke();
            }
        }
        else
        {
            image.color = Color.gray;
        }
    }


}
