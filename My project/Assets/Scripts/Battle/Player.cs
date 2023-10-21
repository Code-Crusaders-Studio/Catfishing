using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject enemy;
    public int maxHp, curHp, dmg, heal;
    public bool lose = false;

    private void Start()
    {
        maxHp = 100;
        curHp = maxHp;
        dmg = 15;
        heal = 20;

        enemy = GameObject.Find("Fish");
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            lose = true;
        }
    }

    public void Attack()
    {
        int hitChance = Random.Range(0, 5); //0 = erra, 1, 2 ou 3 = ataque normal, 4 = crítico

        if (hitChance == 0)
        {
            Debug.Log("Gato errou");
        }
        else if (hitChance == 4)
        {
            enemy.GetComponent<Enemy>().curHp -= dmg * 2;

            Debug.Log("Gato deu dano crítico");
        }
        else
        {
            enemy.GetComponent<Enemy>().curHp -= dmg;
        }

        BattleControl.curTurn = 1;

        Debug.Log("Gato atacou | Hp do peixe: " + enemy.GetComponent<Enemy>().curHp);
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

            Debug.Log("Gato curou | Hp do gato: " + curHp);
        }
        else
        {
            Debug.Log("Gato está com a vida máxima. Escolha outra ação");
        }

        BattleControl.curTurn = 1;
    }

    public void Special()
    {
        BattleControl.curTurn = 1;

        Debug.Log("Gato usou especial");
    }
}
