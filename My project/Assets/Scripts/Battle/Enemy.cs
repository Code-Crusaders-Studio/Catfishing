using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public int maxHp, curHp, dmg, heal;
    public static bool lose = false;

    private void Start()
    {
        maxHp = 100;
        curHp = maxHp;
        dmg = 15;
        heal = 20;

        player = GameObject.Find("Cat");
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            lose = true;
        }

        EnemyAI();
    }

    public void Attack()
    {
        int hitChance = Random.Range(0, 4); //0 = erra, 3 = crítico, 1 ou 2 = ataque normal

        if (hitChance == 0)
        {
            Debug.Log("Peixe errou");
        }
        else if (hitChance == 3)
        {
            player.GetComponent<Player>().curHp -= dmg * 2;

            Debug.Log("Peixe deu dano crítico");
        }
        else
        {
            player.GetComponent<Player>().curHp -= dmg;
        }

        BattleControl.curTurn = 0;

        Debug.Log("Peixe atacou | Hp do gato: " + player.GetComponent<Player>().curHp);
    }

    public void Heal()
    {
        if (curHp != maxHp)
        {
            curHp += heal;

            if (curHp > maxHp)
            {
                curHp = maxHp;
            }

            Debug.Log("Peixe curou | Hp do peixe: " + curHp);
        }

        BattleControl.curTurn = 0;
    }

    public void Special()
    {
        BattleControl.curTurn = 0;

        Debug.Log("Peixe usou especial");
    }

    private void EnemyAI()
    {
        if (BattleControl.curTurn == 1)
        {
            int randomAction = Random.Range(0, 3);

            if (randomAction == 0)
            {
                Attack();
            }
            else if (curHp != maxHp && randomAction == 1)
            {
                Heal();
            }
            else if (randomAction == 2)
            {
                Special();
            }
        }
    }
}
