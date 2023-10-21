using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 5;

    void Update()
    {
        
    }

    public void Attack(GameObject fish)
    {
        fish.GetComponent<Fish>().life--;

        Debug.Log("Vida do peixe" + fish.GetComponent<Fish>().life);
    }

    public void Recover()
    {        
        if(life < 10)
        {
            life++;
        }
        Debug.Log("Vida do gato" + life);
    }
}
