using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishsFishing : MonoBehaviour
{
    //Velocidade andando, acrescimo de velocidade quando ele correr, velocidade final
    private float spdNormal = 5f, spdRun = 3f, spdFinal;
    //Direção para qual o peixe vai andar
    private int dirX;
    //Tipo do peixe (Importante para saber qual peixe foi pescado)
    public int typeFish;

    void Start()
    {
        //Dando uma direção inicial ao peixe
        int rand = Random.Range(0, 10);

        if(rand < 5)
            dirX = -1;
        else 
            dirX = 1;

        //Como a velocidade final inicia sem valor, estou atribuindo a velocidade normal à ela
        spdFinal = spdNormal;
    }

    void Update()
    {
        //Método para movimentar o peixe
        MoveFish();
    }

    void MoveFish()
    {
        //Limitando o espaço onde o peixe pode se movimentar
        if(transform.position.x > 5.5f || transform.position.x < -5.5f){
            dirX *= -1;
        }
        //Movendo o peixe
        transform.Translate(new Vector2(dirX * spdFinal, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        switch(other.gameObject.tag){
            //Se a pata passou em cima do peixe ele pode mudar de direção
            case "Paw":
                int rand = Random.Range(0, 10);

                if(rand < 5)
                    dirX = -1;
                else 
                    dirX = 1;

                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        switch(other.gameObject.tag){
            //Enquanto a pata estiver em cima do peixe, a velocidade final dele é a normal somada com o acréscimo de corrida
            case "Paw":
                spdFinal = spdNormal + spdRun;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        switch(other.gameObject.tag){
            //Retornando para a velocidade normal quando a pata sai de cima do peixe
            case "Paw":
                spdFinal = spdNormal;
                break;
        }
    }
}
