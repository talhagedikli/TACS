using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool alarmSounded;
    public SceneAsset nextLevel;
    public float secondsBeforeNextLevel;
    public float graceTimeAtEndOfLevel;

    public float secondsBeforeShowingDeathMenu;

    bool showDeathMenu;

    private void Awake() 
    {
        References.levelManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        References.alarmManager.SetUpLevel(3);
        showDeathMenu = false;
        secondsBeforeNextLevel = graceTimeAtEndOfLevel;
    }

    // Update is called once per frame
    void Update()
    {
        // If all enemies are dead, go to next level
        if (References.allEnemies.Count < 1)
        {
            // Wait a bit
            secondsBeforeNextLevel -= Time.deltaTime;
            if (secondsBeforeNextLevel <= 0) 
            {
                // Go to next level
                SceneManager.LoadScene(nextLevel.name);
            }
        }
        else
        {
            // Not all enemies dead
            secondsBeforeNextLevel = graceTimeAtEndOfLevel;
        }

        if (References.thePlayer == null && showDeathMenu == false)
        {
            secondsBeforeShowingDeathMenu -= Time.deltaTime;
            if (secondsBeforeShowingDeathMenu <= 0)
            {
                References.canvas.ShowMainMenu();
                showDeathMenu = true;
            }
        }
    }
}
