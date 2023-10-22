using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int maxHp, curHp, dmg, heal;
    [SerializeField] public string specialType;
    public bool isDead = false;
    private int healCd = 1, specialCd = 3;
    private GameObject enemy;

    private void Start()
    {
        curHp = maxHp;

        BattleControl.player = this.gameObject;
        enemy = BattleControl.enemy;
    }

    private void Update()
    {
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
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

            Debug.Log("Gato deu dano crítico | Hp do peixe: " + enemy.GetComponent<Enemy>().curHp);
        }
        else
        {
            enemy.GetComponent<Enemy>().curHp -= dmg;

            Debug.Log("Gato atacou | Hp do peixe: " + enemy.GetComponent<Enemy>().curHp);
        }

        specialCd++;
        healCd++;
        BattleControl.curTurn = 1;
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
                BattleControl.curTurn = 1;

                Debug.Log("Gato curou | Hp do gato: " + curHp);
            }
            else
            {
                Debug.Log("Gato está com a vida máxima. Escolha outra ação");
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
                case "Especial1":
                    Debug.Log("Gato usou especial 1");
                    break;
                case "Especial2":
                    Debug.Log("Gato usou especial 2");
                    break;
                case "Especial3":
                    Debug.Log("Gato usou especial 3");
                    break;
            }

            healCd++;
            specialCd = 0;
            BattleControl.curTurn = 1;
        }
        else
        {
            Debug.Log("Especial em cooldown");
        }
    }
}
