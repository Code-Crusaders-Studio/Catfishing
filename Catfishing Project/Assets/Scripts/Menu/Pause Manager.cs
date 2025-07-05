using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string continueScene, menuScene;

    public void Continue()
    {
        sceneLoader.Transition(continueScene);
    }

    public void Options()
    {
 
    }

    public void Menu()
    {
        sceneLoader.Transition(menuScene);
    }
}
