using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecking : MonoBehaviour
{
    void Start ()
	{
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "Selection" || sceneName == "Intro") 
		{
			Cursor.visible = false; 
		}
		else
		{
			Cursor.visible = true; 
		}
	}
}
