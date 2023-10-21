using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    public int maxHp, curHp, dmg, heal;
    [SerializeField]
    public string specialType;
    private int cooldownHeal;
    public bool lose = false;

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
            lose = true;
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

            Debug.Log("Peixe deu dano crítico");
        }
        else
        {
            player.GetComponent<Player>().curHp -= dmg;
        }

        BattleControl.curTurn = 0;

        Debug.Log("Peixe atacou | Hp do gato: " + player.GetComponent<Player>().curHp);
    }

    public void Heal(int curCooldown)
    {
        int maxCooldown = 1;

        if(curCooldown >= maxCooldown){
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
            curCooldown = 0;
        }
        else
        {
            Debug.Log("Cooldown");
        }
    }

    public void Special(string specialType)
    {
        BattleControl.curTurn = 0;
        switch(specialType)
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
            int randomAction = Random.Range(0, 3);

           if (randomAction == 0)
            {
                Attack();
                cooldownHeal++;
            }
            else if (randomAction == 1)
            {
                Heal(cooldownHeal);
            }
            else if (randomAction == 2)
            {
                Special(specialType);
                cooldownHeal++;
            }
        }
    }
}
