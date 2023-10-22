using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject enemy;

    public int maxHp, curHp, dmg, heal;
    public string specialType;

    public bool isDead = false,  burning = false;
    private bool isBuffed = false, canBurn = false;

    private int healCd = 1, specialCd = 3;

    private void Start()
    {
        BattleControl.player = this.gameObject;
        enemy = BattleControl.enemy;

        specialType = SelectionManager.specialTypePlayer;

        curHp = maxHp;        
    }

    private void Update()
    {
        Dead();
        Burnning();
    }

    private void Dead()
    {
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }
    }

    private void Burnning()
    {
        if(BattleControl.curTurn == 0)
        {
            canBurn = true;
        }

        if(canBurn && burning && BattleControl.curTurn == 1)
        {
            curHp -= 5;
            Debug.Log("Gato está queimando");

            canBurn = false;
        }
    }

    public void Attack()
    {
            int hitChance = Random.Range(0, 5); //0 = erra, 1, 2 ou 3 = ataque normal, 4 = crítico

            if (isBuffed)
            {
                int dmgBuff = dmg * 2;

                if (hitChance <= 1)
                {
                    Debug.Log("Buff / Gato errou");
                }
                else if (hitChance >= 3)
                {
                    enemy.GetComponent<Enemy>().curHp -= dmgBuff * 2;

                    Debug.Log("Buff / Gato deu dano crítico | Dano: " + dmgBuff * 2);
                }
                else
                {
                    enemy.GetComponent<Enemy>().curHp -= dmgBuff;

                    Debug.Log("Buff / Gato atacou | Dano: " + dmgBuff);
                }

                isBuffed = false;
            }
            else
            {
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
            }

            specialCd++;
            healCd++;
            BattleControl.curTurn = 1;
    }

    public void Heal()
    {
        if(BattleControl.curTurn == 0){
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
    }

    public void Special()
    {
        if(BattleControl.curTurn == 0){
            int cdCounter = 3;

            if(specialType != null){
                if (specialCd >= cdCounter)
                {
                    switch (specialType)
                    {
                        case "Queimar":
                            Burn();
                            Debug.Log("Gato usou Queimar");
                            break;
                        case "Congelar":
                            Frost();
                            Debug.Log("Gato usou Congelar");
                            break;
                        case "Enfurecer":
                            Buff();
                            Debug.Log("Gato usou Enfurecer");
                            break;
                    }

                    healCd++;
                    specialCd = 0;
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

    private void Buff()
    {
        isBuffed = true;

        BattleControl.curTurn = 1;
    }

    private void Burn()
    {
        enemy.GetComponent<Enemy>().burning = true;

        BattleControl.curTurn = 1;         
    }

    private void Frost()
    {
        enemy.GetComponent<Enemy>().curHp -= 10;
        BattleControl.curTurn = 0;
    }
}