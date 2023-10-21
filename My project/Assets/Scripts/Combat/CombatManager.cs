using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public TMP_Text fishNameDisplay;
    public static int curTurn; //0 = Gato, 1 = Peixe

    void Start()
    {
        switch (SelectionManager.selectedFish)
        {
            case 0:
            fishNameDisplay.text = "Peixe Padrão";
            break;
            case 1:
            fishNameDisplay.text = "Peixe Realista";
            break;
            case 2:
            fishNameDisplay.text = "Peixe Pixel";
            break;
        }

        curTurn = Random.Range(0, 2);
    }

    void Update()
    {
        
    }
}
