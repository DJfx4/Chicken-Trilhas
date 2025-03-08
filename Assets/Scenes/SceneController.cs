using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string goToScene = "HomeScene";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Clicou no Espaço!");
            SceneManager.LoadScene(goToScene);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC!");
            Application.Quit();
        }
    }
}
