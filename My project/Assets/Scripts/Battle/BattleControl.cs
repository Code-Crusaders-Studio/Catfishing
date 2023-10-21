using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleControl : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    public TMP_Text fishNameDisplay, fishHpDisplay, catHpDisplay;
    public static int curTurn; //0 = Gato, 1 = Peixe

    void Start()
    {
        player = GameObject.Find("Cat");
        enemy = GameObject.Find("Fish");

        switch (SelectionManager.selectedFish)
        {
            case 1:
            fishNameDisplay.text = "Peixe Padrão";
            break;
            case 2:
            fishNameDisplay.text = "Peixe Realista";
            break;
            case 3:
            fishNameDisplay.text = "Peixe Pixel";
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

        if (Player.lose)
        {
            //Trocar pra cena de Game Over
        }

        if (Enemy.lose)
        {
            SceneManager.LoadScene("Selection");
        }
    }
}
