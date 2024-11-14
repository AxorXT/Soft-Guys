using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNivelCompletado : MonoBehaviour
{


    // Método que cambiará a la siguiente escena
    public void LoadNextLevel()
    {
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Cambia a la siguiente escena
        SceneManager.LoadScene(currentSceneIndex + 1);
    
}
public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

}