using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHp, curHp, dmg, heal;
    [SerializeField] public string specialType;
    public bool isDead = false;
    private int healCd, specialCd;
    private GameObject player;

    private void Start()
    {
        curHp = maxHp;
        player = BattleControl.player;
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }

        EnemyAI();
    }

    public void Attack()
    {
        int hitChance = Random.Range(0, 5); //0 = erra, 1, 2 ou 3 = ataque normal, 4 = crítico

        if (hitChance == 0)
        {
            Debug.Log("Peixe errou");
        }
        else if (hitChance == 4)
        {
            player.GetComponent<Player>().curHp -= dmg * 2;

            Debug.Log("Peixe deu dano crítico | Hp do gato: " + player.GetComponent<Player>().curHp);
        }
        else
        {
            player.GetComponent<Player>().curHp -= dmg;

            Debug.Log("Peixe atacou | Hp do gato: " + player.GetComponent<Player>().curHp);
        }

        BattleControl.curTurn = 0;
    }

    public void Heal(int cdValue)
    {
        int cdCounter = 1;

        if (cdValue >= cdCounter)
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

            cdValue = 0;
            BattleControl.curTurn = 0;
        }
        else
        {
            Debug.Log("Cura em cooldown");
        }
    }

    public void Special(string specialType)
    {
        BattleControl.curTurn = 0;

        switch (specialType)
        {
            case "Especial1":
                Debug.Log("Peixe usou especial 1");
                break;
            case "Especial2":
                Debug.Log("Peixe usou especial 2");
                break;
            case "Especial3":
                Debug.Log("Peixe usou especial 3");
                break;
        }
    }

    private void EnemyAI()
    {
        if (BattleControl.curTurn == 1)
        {
            int rAction = Random.Range(0, 3);

            if (rAction == 0)
            {
                Attack();
                healCd++;
            }
            else if (rAction == 1)
            {
                Heal(healCd);
            }
            else if (rAction == 2)
            {
                Special(specialType);
                healCd++;
            }
        }
    }
}
