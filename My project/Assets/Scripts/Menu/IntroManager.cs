using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public SceneLoaderForIntro sceneLoaderForIntro;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoaderForIntro.Transition(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
