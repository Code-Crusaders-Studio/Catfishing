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

        specialType = SelectionManager.specialTypePlayer;

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

        if(specialType != null){
            if (specialCd >= cdCounter)
            {
                switch (specialType)
                {
                    case "Queimar":
                        Debug.Log("Gato usou Queimar");
                        break;
                    case "Congelar":
                        Debug.Log("Gato usou Congelar");
                        break;
                    case "Enfurecer":
                        Debug.Log("Gato usou Enfurecer");
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
        else
        {
            Debug.Log("Você ainda não possui um ataque especial");
        }
    }
}
