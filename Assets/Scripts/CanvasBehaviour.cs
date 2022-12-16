using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class CanvasBehaviour : MonoBehaviour
{
    public SceneAsset firstScene;
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject currentMenu;

    // Start is called before the first frame update
    // Awake happens before start
    void Awake()
    {
        References.canvas = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (currentMenu == mainMenu)
            {
                HideMenu();
            }
            else
            {
                ShowMenu(mainMenu);
            }
        }
    }
    public void HideMenu()
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }
        currentMenu = null;
        Time.timeScale = 1;
    }

    public void ShowMenu(GameObject menuToShow)
    {
        HideMenu();
        currentMenu = menuToShow;
        if (menuToShow != null)
        {
            menuToShow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ShowMainMenu()
    {
        ShowMenu(mainMenu);
    }


    public void StartNewGame()
    {
        HideMenu();
        SceneManager.LoadScene(firstScene.name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
