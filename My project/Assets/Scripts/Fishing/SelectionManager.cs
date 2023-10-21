using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager
{
    //Variavel que guarda se começamos um jogo novo (Importante para diferenciar o início do jogo com o retorno para a pesca após os combates)
    public static bool startGame = true;
    //Lista que guarda os tipos de peixes restantes
    public static LinkedList<int> curFishs;

    public static int selectedFish;
}
