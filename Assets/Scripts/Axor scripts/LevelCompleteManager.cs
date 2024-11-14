using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleteManager : MonoBehaviour
{
    public TextMeshProUGUI levelCompleteTimeText; // El texto que se mostrar� en el panel de nivel completado
    public PlayerTime playerTime; // Referencia al script que maneja el cron�metro
    public GameObject levelCompletedMenu; // El panel de "Nivel Completado"
    public GameObject levelFailedMenu;    // El panel de "Nivel Fallado" (si lo necesitas)
    public GameObject player;  // Referencia al objeto del jugador (para desactivar su movimiento)
    public GameObject playerController; // Referencia al controlador del jugador (o el script que gestiona el movimiento)


    // M�todo para mostrar el panel de nivel completado
    public void ShowLevelCompletedMenu()
    {
        if (playerTime != null)
        {
            // Obtener el tiempo del cron�metro (aseg�rate de que el cron�metro est� detenido)
            float time = playerTime.timeRemaining;

            // Mostrar el tiempo en el panel de "Nivel Completado"
            if (levelCompleteTimeText != null)
            {
                levelCompleteTimeText.text = time.ToString("F2") + " segundos";
            }
        }

        // Mostrar el panel de nivel completado
        levelCompletedMenu.SetActive(true);

        // Si tienes un panel de nivel fallado, lo desactivamos
        if (levelFailedMenu != null)
        {
            levelFailedMenu.SetActive(false);
        }

        // Mostrar el puntero del rat�n
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Desactivar el movimiento del jugador
        if (player != null && playerController != null)
        {
            // Si tienes un script de movimiento, puedes desactivarlo aqu�
            playerController.SetActive(false);  // Desactiva el controlador de movimiento
        }
    }
}