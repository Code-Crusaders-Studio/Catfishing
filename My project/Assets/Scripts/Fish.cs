using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int life = 10;

    void Update()
    {
        if(life <= 0){
            Debug.Log("Peixe morreu");
        }
    }
}
