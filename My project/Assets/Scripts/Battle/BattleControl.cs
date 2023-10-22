using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleControl : MonoBehaviour
{
    public static GameObject enemy, player;
    public GameObject[] prefFishs;
    public TMP_Text fishNameDisplay, fishHpDisplay, catHpDisplay;
    public static int curTurn; //0 = Gato, 1 = Peixe

    void Start()
    {
        player = GameObject.Find("Cat");

        switch (SelectionManager.selectedFish)
        {
            case 0:
                fishNameDisplay.text = "Peixe Sol";
                enemy = Instantiate(prefFishs[0]);
                break;
            case 1:
                fishNameDisplay.text = "Peixe Lua";
                enemy = Instantiate(prefFishs[1]);
                break;
            case 2:
                fishNameDisplay.text = "Peixe Bombado";
                enemy = Instantiate(prefFishs[2]);
                break;
        }

        curTurn = Random.Range(0, 2);

        if (curTurn == 0)
        {
            Debug.Log("Turno do gato");
        }
        else
        {
            Debug.Log("Turno do peixe");
        }
    }

    void Update()
    {
        fishHpDisplay.text = enemy.GetComponent<Enemy>().curHp + " / " + enemy.GetComponent<Enemy>().maxHp;
        catHpDisplay.text = player.GetComponent<Player>().curHp + " / " + player.GetComponent<Player>().maxHp;

        if (player.GetComponent<Player>().isDead)
        {
            //Trocar pra cena de Game Over
        }

        if (enemy.GetComponent<Enemy>().isDead)
        {
            SceneManager.LoadScene("Selection");
        }
    }
}
