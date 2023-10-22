using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{   
    Animator anim;
    int painel = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Intro());

    }

    // Update is called once per frame
    void Update()
    {
        switch (painel)
        {
            case 0:
            anim.SetInteger("estado", 0);
            break;
            case 1:
            anim.SetInteger("estado", 1);
            break;
            case 2:
            anim.SetInteger("estado", 2);
            break;
            case 3:
            anim.SetInteger("estado", 3);
            break;
            case 4:
            anim.SetInteger("estado", 4);
            break;
            case 5:
            anim.SetInteger("estado", 5);
            break;
            case 6:
            anim.SetInteger("estado", 6);
            break;


        }
    }

     IEnumerator Intro(float cronometro = 5f)
     {
        while (true)
        {

        yield return new WaitForSeconds(cronometro);
        painel++;

        if (painel == 6)
        StopCoroutine(Intro());

        }

     }

}
