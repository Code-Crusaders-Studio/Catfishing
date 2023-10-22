using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Paw : MonoBehaviour
{
    void Update()
    {
        //Método de movimentação da pata
        MovePaw();
        //Método responsável pela pesca
        ToFish();
    }

    void MovePaw()
    {
        //A posição da pata é igual a posição do mouse na tela
        Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(posMouse.x, posMouse.y, transform.position.z);

        if(transform.position.x > 5)
        {
            transform.position = new Vector2(5, transform.position.y);
        }
        else if(transform.position.x < -5)
        {
            transform.position = new Vector2(-5, transform.position.y);
        }

        if(transform.position.y > 2)
        {
            transform.position = new Vector2(transform.position.x, 2);
        }
        else if(transform.position.y < -3)
        {
            transform.position = new Vector2(transform.position.x, -3);
        }
    }

    void ToFish()
    {
        //Quando apertamos o botão esquerdo do mouse, lançamos um raycast de um único ponto e verificamos se ele colidiu com algo
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                TouchCollision(hit);
            }
        }
    }

    void TouchCollision(RaycastHit2D hit)
    {
        switch(hit.collider.gameObject.tag)
        {
            //Se o raycast colidiu com o peixe então criamos um node que leva como valor o tipo do peixe que colidimos, removemos da lista com os tipos de peixes, o peixe que possui esse node como valor e depois vamos para o combate
            case "Fish":
                LinkedListNode<int> fish = SelectionManager.curFishs.Find(hit.collider.gameObject.GetComponent<FishsFishing>().typeFish);
                SelectionManager.selectedFish = fish.Value;
                SelectionManager.curFishs.Remove(fish);
                SceneManager.LoadScene("Battle");
                break;
        }
    }
}
