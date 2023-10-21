using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paw : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, speed;
    private bool onFish = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(dirX, dirY) * speed;

        if (Input.GetKeyDown(KeyCode.Space) && onFish)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fish"))
        {
            onFish = true;

            switch(col.gameObject.name)
            {
                case "Padrão":
                SelectionManager.selectedFish = 1;
                break;
                case "Realista":
                SelectionManager.selectedFish = 2;
                break;
                case "Pixel":
                SelectionManager.selectedFish = 3;
                break;
            }

            Debug.Log(SelectionManager.selectedFish);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fish"))
        {
            onFish = false;
        }
    }
}
