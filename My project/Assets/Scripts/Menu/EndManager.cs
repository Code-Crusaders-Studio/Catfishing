using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneName;

    void Start()
    {
        sceneLoader.Transition(sceneName);
    }
}
