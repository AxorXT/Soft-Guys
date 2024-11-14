using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenuManager : MonoBehaviour
{
    public GameObject playerObject;       // El objeto del jugador
    public Transform playerStartPosition; // Posici�n inicial del jugador
    public GameObject levelCompletedMenu; // Panel de Nivel Completado
    public GameObject levelFailedMenu;    // Panel de Nivel Fallado (Reintentar)
    public PlayerTime playerTime;         // Referencia al cron�metro del jugador
    public KillPlayerOnCollision killplayer;

    // Para mostrar el tiempo en el panel de nivel completado
    public TextMeshProUGUI levelCompleteTimeText; // Texto que mostrar� el tiempo
    private string levelCompleteTimeString;

    // Mostrar el men� de nivel completado
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

    // Mostrar el men� de nivel fallado (cuando el jugador muere)
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

        // Ocultar el puntero despu�s de seleccionar la opci�n
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }

    // Reintentar nivel
    public void RetryLevel()
    {
        // Asegurarse de que playerStartPosition est� asignado en el Inspector
        if (playerStartPosition != null)
        {
            // Reposicionar al jugador en la posici�n inicial
            playerObject.transform.position = playerStartPosition.position;

            // Reactivar el objeto "Player"
            playerObject.SetActive(true);

            // Reiniciar el cron�metro si es necesario
            if (playerTime != null)
            {
                playerTime.ResetTimer(); // Reinicia el cron�metro si es necesario
            }
            // Reactivar el movimiento del jugador
            if (killplayer != null)
            {
                killplayer.EnablePlayerMovement();
            }
        }
        

        // Ocultar el panel de reintentar
        levelFailedMenu.SetActive(false);

        // Ocultar el puntero despu�s de seleccionar la opci�n
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }

    public void RetryLevelEnd()
    {
        // Recargar la escena actual para que el jugador comience desde el inicio
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Opcional: Ocultar el puntero despu�s de seleccionar la opci�n
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Volver al men� principal
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Asume que la escena principal se llama "MainMenu"

        // Ocultar el puntero despu�s de seleccionar la opci�n
        Cursor.visible = false;  // Hacer invisible el puntero
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el puntero al centro de la pantalla
    }
}
