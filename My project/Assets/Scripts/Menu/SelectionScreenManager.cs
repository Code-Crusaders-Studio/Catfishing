using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScreenManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneLoader.Transition(sceneName);
        }
    }
}
