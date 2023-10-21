using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject cat;

    public int life = 5;

    public int curSpecial = 1;

    private void Start()
    {
        cat = GameObject.Find("Cat");    
    }

    private void Update() 
    {
        if(CombatController.curTurn == 'f')
        {
            float rand = Random.Range(0, 10);

            if(rand < 6)
            {
                Attack();
            }
            else if(rand > 6 && rand < 9)
            {
                Recover();
            }
            else if(rand > 8)
            {
                Special();
            }
        }
    }

    public void Attack()
    {
        if(cat.GetComponent<Player>().life > 0)
        {
            cat.GetComponent<Player>().life--;
        }

        CombatController.curTurn = 'c';

        Debug.Log("Peixe atacou! Vida do gato: " + cat.GetComponent<Player>().life);
    }

    public void Recover()
    {        
        if(life < 10)
        {
            life++;
        }

        CombatController.curTurn = 'c';

        Debug.Log("Peixe recuperou vida! Vida do peixe: " + life);
    }

    public void Special()
    {
        CombatController.curTurn = 'f';

        Debug.Log("Peixe usou o especial " + life);
    }
}
