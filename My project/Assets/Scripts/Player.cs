using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject fish;

    public int life = 5;

    //variável do especial
    public int curSpecial = 1;

    private void Start()
    {
        fish = GameObject.Find("Fish");    
    }

    private void Update()
    {
        
    }

    public void Attack()
    {
        if(fish.GetComponent<Fish>().life > 0)
        {
            fish.GetComponent<Fish>().life--;
        }
        
        CombatController.curTurn = 'f';

        Debug.Log("Gato atacou! Vida do peixe: " + fish.GetComponent<Fish>().life);
    }

    public void Recover()
    {        
        if(life < 10)
        {
            life++;
        }

        CombatController.curTurn = 'f';

        Debug.Log("Gato recuperou vida! Vida do gato: " + life);
    }

    public void Special()
    {
        CombatController.curTurn = 'c';

        Debug.Log("Gato usou o especial " + life);
    }
}
