using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject cat;

    public int enemyHp = 5;

    public int curSpecial = 1;

    private void Start()
    {
        cat = GameObject.Find("Cat");    
    }

    private void Update() 
    {
        if(CombatManager.curTurn == 1)
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

        if(enemyHp <= 0)
        SceneManager.LoadScene("Selection");
    }

    public void Attack()
    {
        if(cat.GetComponent<Player>().playerHp > 0)
        {
            cat.GetComponent<Player>().playerHp--;
        }

        CombatManager.curTurn = 0;

        Debug.Log("Peixe atacou! Vida do gato: " + cat.GetComponent<Player>().playerHp);
    }

    public void Recover()
    {        
        if(enemyHp < 10)
        {
            enemyHp++;
        }

        CombatManager.curTurn = 0;

        Debug.Log("Peixe recuperou vida! Vida do peixe: " + enemyHp);
    }

    public void Special()
    {
        CombatManager.curTurn = 1;

        Debug.Log("Peixe usou o especial " + enemyHp);
    }
}
