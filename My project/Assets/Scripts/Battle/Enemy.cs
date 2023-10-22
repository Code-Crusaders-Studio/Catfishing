using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHp, curHp, dmg, heal;
    [SerializeField] public string specialType;
    public bool isDead = false, isBuffed = false;
    private int healCd = 1, specialCd = 3;
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
        int hitChance = Random.Range(0, 5); //Sem estar buffado: 0 = erra, 1, 2 ou 3 = ataque normal, 4 = crítico || Buffado: 0 ou 1 = erro, 2 = ataque normal, 3 ou 4 = crítico

        if (isBuffed)
        {
            if (hitChance <= 1)
            {
                Debug.Log("Peixe errou");
            }
            else if (hitChance >= 3)
            {
                player.GetComponent<Player>().curHp -= dmg * 2;

                Debug.Log("Peixe deu dano crítico | Hp do gato: " + player.GetComponent<Player>().curHp);
            }
            else
            {
                player.GetComponent<Player>().curHp -= dmg;

                Debug.Log("Peixe atacou | Hp do gato: " + player.GetComponent<Player>().curHp);
            }
        }
        else
        {
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
        }

        BattleControl.curTurn = 0;
    }

    public void Heal()
    {
        int cdCounter = 1;

        if (healCd >= cdCounter)
        {
            if (curHp != maxHp)
            {
                curHp += heal;

                if (curHp > maxHp)
                {
                    curHp = maxHp;
                }

                specialCd++;
                healCd = 0;
                BattleControl.curTurn = 0;

                Debug.Log("Peixe curou | Hp do peixe: " + curHp);
            }
            else
            {
                Debug.Log("Peixe está com a vida máxima.");
            }
        }
        else
        {
            Debug.Log("Cura em cooldown");
        }
    }

    public void Special()
    {
        int cdCounter = 3;

        if (specialCd >= cdCounter)
        {
            switch (specialType)
            {
                case "Queimar":
                    Debug.Log("Peixe usou Queimar");
                    break;
                case "Congelar":
                    Debug.Log("Peixe usou Congelar");
                    break;
                case "Enfurecer":
                    Buff();
                    Debug.Log("Peixe usou Enfurecer | Dano: " + dmg); 
                    break;
            }

            healCd++;
            specialCd = 0;
            BattleControl.curTurn = 0;
        }
        else
        {
            Debug.Log("Especial em cooldown");
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
                specialCd++;
                healCd++;
            }
            else if (rAction == 1)
            {
                if (curHp < maxHp)
                {
                    Heal();
                    specialCd++;
                }
                else
                {
                    rAction = Random.Range(0, 3);
                }

            }
            else if (rAction == 2)
            {
                if (specialCd >= 3)
                {
                    Special();
                    healCd++;
                }
                else
                {
                    rAction = Random.Range(0, 3);
                }
            }
        }
    }

    private void Buff()
    {
        dmg *= 2;
        isBuffed = true;
    }
}
