using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{


    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        
        Application.Quit();
    }

}