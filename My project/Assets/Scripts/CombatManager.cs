using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public TMP_Text fishNameDisplay;

    void Start()
    {
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
    }

    void Update()
    {
        
    }
}
