using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string nextLevelName = "Level 1";
    public Image itemImage;

    public PlayerAudioController audioController;

    bool canWinlevel = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("PlAYER TOCOU NO INIMIGO, ENTÃO PERDEU!!!");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        { 
            Debug.Log("PLAYER PEGOU O ITEM!");
            Destroy(collision.gameObject);
            itemImage.color = Color.white;
            canWinlevel = true;
            audioController.PlayGetItem();
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWinlevel)
            {
                Debug.Log("PLAYER GANHOU O LEVEL!!!");
                SceneManager.LoadScene(nextLevelName);
            } else
            {
                Debug.Log("PLAYER NÃO GANHOU O LEVEL!!!");
            }
        }
    }

}
