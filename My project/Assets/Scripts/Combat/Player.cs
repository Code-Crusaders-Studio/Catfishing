using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject enemy;

    public int playerHp = 5;

    //variável do especial
    public int curSpecial = 1;

    private void Start()
    {
        enemy = GameObject.Find("Fish");    
    }

    private void Update()
    {
        
    }

    public void Attack()
    {
        if(enemy.GetComponent<Enemy>().enemyHp > 0)
        {
            enemy.GetComponent<Enemy>().enemyHp--;
        }
        
        CombatManager.curTurn = 1;

        Debug.Log("Gato atacou! Vida do peixe: " + enemy.GetComponent<Enemy>().enemyHp);
    }

    public void Recover()
    {        
        if(playerHp < 10)
        {
            playerHp++;
        }

        CombatManager.curTurn = 1;

        Debug.Log("Gato recuperou vida! Vida do gato: " + playerHp);
    }

    public void Special()
    {
        CombatManager.curTurn = 0;

        Debug.Log("Gato usou o especial " + playerHp);
    }
}
