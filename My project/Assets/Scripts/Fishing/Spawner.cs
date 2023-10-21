using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Prefabs dos peixes
    public GameObject[] prefFishs;
    //Prefab que guarda todos os tipos de peixes
    public int[] valueOfPrefFishs = {0, 1, 2};
    //Lista que guarda os tipos de peixes que vão ser instanciados
    public LinkedList<int> curFishsObj;

    void Start()
    {
        //Se estamos no início do jogo, coloca todos os peixes na lista e avisa que já não estamos mais no início
        if(SelectionManager.startGame)
        {
            SelectionManager.curFishs = new LinkedList<int> (valueOfPrefFishs);
            SelectionManager.startGame = false;
        }
        //Define a lista dos peixes que serão instanciados como igual a lista de peixes restantes
        curFishsObj = SelectionManager.curFishs;

        //Percorre a lista de peixes que serão instanciados e verifica se o tipo de peixe da lista ainda existe, se sim, ele vai instanciar o peixe daquele tipo
        foreach(int instFish in curFishsObj)
        {
            if(instFish == prefFishs[instFish].GetComponent<FishsFishing>().typeFish)
            {
                Instantiate(prefFishs[instFish]);
            }
        }
    }
}
