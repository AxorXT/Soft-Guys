using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public void Play(string Demo01)
    {
        SceneManager.LoadScene(Demo01);
    }



    public void Exit()
    {
        Application.Quit();
        Debug.Log("Aqui se sale del Juego");


    }
}