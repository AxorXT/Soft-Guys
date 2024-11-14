using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenuManager : MonoBehaviour
{
    public GameObject playerObject;       // El objeto del jugador
    public Transform playerStartPosition; // Posición inicial del jugador
    public GameObject levelCompletedMenu; // Panel de Nivel Completado
    public GameObject levelFailedMenu;    // Panel de Nivel Fallado (Reintentar)
    public PlayerTime playerTime;         // Referencia al cronómetro del jugador
    public KillPlayerOnCollision killplayer;

    // Para mostrar el tiempo en el panel de nivel completado
    public TextMeshProUGUI levelCompleteTimeText; // Texto que mostrará el tiempo
    private string levelCompleteTimeString;

    // Mostrar el menú de nivel completado
    public void ShowLevelCompletedMenu()
    {
        // Mostrar el tiempo en el panel de "Nivel Completado"
        if (playerTime != null)
        {
            float time = playerTime.timeRemaining; // Obtener el tiempo
            levelCompleteTimeString = "Tiempo: " + time.ToString("F2") + " segundos";
        }

        if (levelCompleteTimeText != null)
        {
            levelCompleteTimeText.text = levelCompleteTimeString; // Mostrar el tiempo en el texto del panel
        }

        levelCompletedMenu.SetActive(true);
        levelFailedMenu.SetActive(false);
    }

    // Mostrar el menú de nivel fallado (cuando el jugador muere)
    public void ShowLevelFailedMenu()
    {
        levelFailedMenu.SetActive(true);
        levelCompletedMenu.SetActive(false);
    }

    // Siguiente nivel
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex); // Carga el siguiente nivel

        // Ocultar el puntero después de seleccionar la opción
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }

    // Reintentar nivel
    public void RetryLevel()
    {
        // Asegurarse de que playerStartPosition esté asignado en el Inspector
        if (playerStartPosition != null)
        {
            // Reposicionar al jugador en la posición inicial
            playerObject.transform.position = playerStartPosition.position;

            // Reactivar el objeto "Player"
            playerObject.SetActive(true);

            // Reiniciar el cronómetro si es necesario
            if (playerTime != null)
            {
                playerTime.ResetTimer(); // Reinicia el cronómetro si es necesario
            }
            // Reactivar el movimiento del jugador
            if (killplayer != null)
            {
                killplayer.EnablePlayerMovement();
            }
        }
        

        // Ocultar el panel de reintentar
        levelFailedMenu.SetActive(false);

        // Ocultar el puntero después de seleccionar la opción
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }

    public void RetryLevelEnd()
    {
        // Recargar la escena actual para que el jugador comience desde el inicio
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Opcional: Ocultar el puntero después de seleccionar la opción
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Volver al menú principal
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Asume que la escena principal se llama "MainMenu"

        // Ocultar el puntero después de seleccionar la opción
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }
}
