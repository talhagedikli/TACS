using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmManager : MonoBehaviour
{
    public GameObject alertPipPrefab;

    public List<Image> alertPips = new List<Image>();

    public int alertLevel;
    public int maxAlertLevel;

    public Color filledPip;
    public Color emptyPip;

    public AudioSource alarmSound;

    private void Awake() 
    {
        References.alarmManager = this;
    }

    private void Start() 
    {
        alarmSound = GetComponent<AudioSource>();
    }

    private void Update() {
        if (AlarmHasSounded() && alarmSound.isPlaying == false)
        {
            alarmSound.Play();
        }
        if (AlarmHasSounded() == false && alarmSound.isPlaying)
        {
            alarmSound.Stop();
        }
    }

    public void SetUpLevel(int desiredMaxAlertLevel)
    {
        maxAlertLevel = desiredMaxAlertLevel;
        // For each alert level, create a pip and store them in a list we can access later
        for (int i = 0; i < desiredMaxAlertLevel; i++)
        {
            //  , transform: makes the new instance my child
            GameObject newPip = Instantiate(alertPipPrefab, transform);
            alertPips.Add(newPip.GetComponent<Image>());
        }
    }

    public void RaiseAlertLevel()
    {
        alertLevel++;
        UpdatePips();
    }

    public void SoundTheAlarm()
    {
        alertLevel = maxAlertLevel;
        UpdatePips();
    }

    void UpdatePips()
    {
        for (int i = 0; i < alertPips.Count; i++)
        {
            if (i < alertLevel)
            {
                alertPips[i].color = filledPip;
            }
            else
            {
                alertPips[i].color = emptyPip;
            }
        }
    }

    public bool AlarmHasSounded()
    {
        return alertLevel >= maxAlertLevel;
    }
}
