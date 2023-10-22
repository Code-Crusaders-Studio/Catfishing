using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderForIntro : MonoBehaviour
{
    public Animator transitionAnim;

    public void Transition(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(12.7f);

        SceneManager.LoadScene(sceneName);
    }
}
