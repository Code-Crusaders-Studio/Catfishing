using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneName;
    public GameObject mainMenu, creditsPanel, optionsPanel;

    public void Play()
    {
        sceneLoader.Transition(sceneName);

        SelectionManager.startGame = true;
        SelectionManager.specialTypePlayer = "";
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Fechou");
    }
}
