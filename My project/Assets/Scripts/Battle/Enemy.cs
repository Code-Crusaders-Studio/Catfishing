using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public AudioClip atkAudio, healAudio, critAudio, burnAudio, frostAudio, buffAudio, deathAudio;
    private AudioSource audioSource;

    public int maxHp, curHp, dmg, heal;
    public string specialType;

    public bool isDead = false, burning = false;
    private bool isBuffed = false, canBurn = false;

    private int healCd = 1, specialCd = 3;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = BattleControl.player;

        curHp = maxHp;
    }

    private void Update()
    {
        EnemyAi();

        Dead();
        Burning();
    }

    private void Dead()
    {
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
            audioSource.PlayOneShot(deathAudio, 0.3f);
        }
    }

    private void Burning()
    {
        if (BattleControl.curTurn == 1)
        {
            canBurn = true;
        }

        if (canBurn && burning && BattleControl.curTurn == 0)
        {
            curHp -= 5;
            Debug.Log("Gato está queimando");
            audioSource.PlayOneShot(burnAudio, 1f);
            canBurn = false;
        }
    }

    public void EnemyAi()
    {
        if (BattleControl.curTurn == 1)
        {
            float action;
            action = Random.Range(0, 30);

            if (action <= 10)
            {
                Attack();

                specialCd++;
                healCd++;
                BattleControl.curTurn = 0;
            }
            else if (action > 10 && action <= 20)
            {
                if (curHp != maxHp && healCd >= 1)
                {
                    Heal();
                    specialCd++;
                    healCd = 0;
                    BattleControl.curTurn = 0;
                }
                else if (curHp == maxHp || healCd < 1)
                {
                    BattleControl.curTurn = 1;
                }
            }
            else
            {
                if (specialCd >= 3)
                {
                    switch (specialType)
                    {
                        case "Queimar":
                            Burn();
                            BattleControl.curTurn = 0;
                            Debug.Log("Peixe usou Queimar");
                            break;
                        case "Congelar":
                            Frost();
                            BattleControl.curTurn = 1;
                            Debug.Log("Peixe usou Congelar");
                            break;
                        case "Enfurecer":
                            Buff();
                            BattleControl.curTurn = 0;
                            Debug.Log("Peixe usou Enfurecer");
                            break;
                    }

                    healCd++;
                    specialCd = 0;
                }
                else
                {
                    BattleControl.curTurn = 1;
                }
            }
        }
    }

    public void Attack()
    {
        if (BattleControl.curTurn == 1)
        {
            int hitChance = Random.Range(0, 5); //0 = erra, 1, 2 ou 3 = ataque normal, 4 = crítico

            if (isBuffed)
            {
                int dmgBuff = dmg * 2;

                if (hitChance <= 1)
                {
                    Debug.Log("Buff / Peixe errou");
                }
                else if (hitChance >= 3)
                {
                    player.GetComponent<Player>().curHp -= dmgBuff * 2;
                    audioSource.PlayOneShot(critAudio, 1f);
                    Debug.Log("Buff / Peixe deu dano crítico | Dano: " + dmgBuff * 2);
                }
                else
                {
                    player.GetComponent<Player>().curHp -= dmgBuff;
                    audioSource.PlayOneShot(atkAudio, 1f);
                    Debug.Log("Buff / Peixe atacou | Dano: " + dmgBuff);
                }

                isBuffed = false;
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
                    audioSource.PlayOneShot(critAudio, 1f);
                    Debug.Log("Peixe deu dano crítico | Hp do gato: " + player.GetComponent<Player>().curHp);
                }
                else
                {
                    player.GetComponent<Player>().curHp -= dmg;
                    audioSource.PlayOneShot(atkAudio, 1f);
                    Debug.Log("Peixe atacou | Hp do gato: " + player.GetComponent<Player>().curHp);
                }
            }
        }
    }

    public void Heal()
    {
        curHp += heal;

        if (curHp > maxHp)
        {
            curHp = maxHp;
        }

        audioSource.PlayOneShot(healAudio, 1f);
        Debug.Log("Peixe curou | Hp do peixe: " + curHp);
    }

    public void Buff()
    {
        isBuffed = true;
        audioSource.PlayOneShot(buffAudio, 1f);
    }

    public void Burn()
    {
        player.GetComponent<Player>().burning = true;
        audioSource.PlayOneShot(burnAudio, 1f);
    }

    public void Frost()
    {
        player.GetComponent<Player>().curHp -= 10;
        audioSource.PlayOneShot(frostAudio, 1f);
    }
}
