using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KillPlayerOnCollision : MonoBehaviour
{
    public Transform playerStartPosition;  // Posición de inicio donde el jugador será regresado
    public GameObject playerObject;       // El objeto vacío que contiene al jugador (por ejemplo, "Player")
    public PlayerTime playerTime;         // Referencia al cronómetro del jugador
    public LevelMenuManager levelMenuManager; // Referencia al script que gestiona los paneles (Nivel Completado / Reintentar)
    public EndLevelCollision endLevel; // Referencia al script de nivel completado
    public TextMeshProUGUI levelFailedTimeText; // Texto para mostrar el tiempo en el panel de nivel fallado
    public PlayerMovementTutorial playerMovement; // Referencia al script de movimiento del jugador

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mostrar el puntero del mouse y liberar el cursor
            Cursor.visible = true; // Hacer visible el cursor
            Cursor.lockState = CursorLockMode.None; // Liberar el cursor si estaba bloqueado

            // Detener el cronómetro y obtener el tiempo transcurrido
            if (playerTime != null)
            {
                playerTime.StopTimer();
                float time = playerTime.timeRemaining;

                // Actualizar el texto del panel de nivel fallado con el tiempo alcanzado
                if (levelFailedTimeText != null)
                {
                    levelFailedTimeText.text = "Tiempo: " + time.ToString("F2") + " segundos";
                }
            }

            // Reiniciar el cronómetro cuando el jugador muera
            if (playerTime != null)
            {
                playerTime.ResetTimer();
            }

            // Desactivar el movimiento del jugador
            if (playerMovement != null)
            {
                playerMovement.enabled = false; // Desactivar el script de movimiento
            }

            // Mostrar el panel de reintentar cuando el jugador muera
            if (levelMenuManager != null)
            {
                levelMenuManager.ShowLevelFailedMenu(); // Mostrar el panel de reintentar
            }
        }
    }

    // Método para reactivar el movimiento cuando el jugador reintente el nivel
    public void EnablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = true; // Reactivar el script de movimiento
        }
    }
}
