using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelCollision : MonoBehaviour
{
    public PlayerTime playerTime;  // Referencia al script que controla el cronómetro
    public LevelCompleteManager levelCompleteManager;  // Referencia al script que maneja el panel de nivel completado
    public MonoBehaviour playerMovementScript;  // Referencia al script que controla el movimiento del jugador

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detener el cronómetro cuando el jugador llegue al final
            if (playerTime != null)
            {
                playerTime.StopTimer();  // Detener el cronómetro
            }

            // Mostrar el panel de nivel completado
            if (levelCompleteManager != null)
            {
                levelCompleteManager.ShowLevelCompletedMenu();  // Mostrar el panel de nivel completado
            }

            // Desactivar el script de movimiento del jugador
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false;
            }

            // Opcionalmente, hacer visible el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
