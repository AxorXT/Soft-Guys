using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNivelCompletado : MonoBehaviour
{


    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

}