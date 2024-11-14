using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerTime : MonoBehaviour
{
    public LevelMenuManager levelMenuManager; // Referencia a la gestión de los menús
    public Camera playerCamera;              // Cámara del jugador desde la cual se lanza el raycast
    public TextMeshProUGUI timerText;        // Texto en UI para mostrar el tiempo
    public float timeRemaining = 0f;         // Tiempo restante del cronómetro
    private bool timerRunning = false;       // Controla si el cronómetro está en marcha

    void Update()
    {
        // Detectar si el jugador hace clic
        if (Input.GetMouseButtonDown(0))
        {
            // Lanzamos un raycast desde el centro de la cámara
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto golpeado tiene la etiqueta "buttonObject" y el cronómetro no está en marcha
                if (hit.transform.CompareTag("buttonObject") && !timerRunning)
                {
                    StartTimer();  // Iniciar cronómetro si se hace clic en el objeto interactivo
                }
            }
        }

        // Si el cronómetro está en marcha, actualiza el tiempo
        if (timerRunning)
        {
            timeRemaining += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // Método para iniciar el cronómetro
    void StartTimer()
    {
        timerRunning = true;
        timeRemaining = 0f; // Reinicia el tiempo cuando comienza el cronómetro
    }

    // Método para actualizar el texto del cronómetro en la UI
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Tiempo: " + timeRemaining.ToString("F2") + " segundos";
        }
    }

    // Método para detener el cronómetro (lo puedes llamar cuando llegues a una meta)
    public void StopTimer()
    {
        timerRunning = false;
        Debug.Log("Cronómetro detenido. Tiempo total: " + timeRemaining + " segundos.");
    }

    // Método para reiniciar el cronómetro (lo puedes llamar cuando el jugador muera)
    public void ResetTimer()
    {
        timerRunning = false;  // Detener el cronómetro
        timeRemaining = 0f;    // Reiniciar el tiempo a cero
        UpdateTimerDisplay();  // Actualizar el texto en pantalla
    }

    // Llamar cuando el jugador complete el nivel
    public void OnLevelComplete()
    {
        StopTimer(); // Detener el cronómetro
        levelMenuManager.ShowLevelCompletedMenu(); // Mostrar el panel de nivel completado
    }

    // Llamar cuando el jugador falle el nivel
    public void OnLevelFailed()
    {
        levelMenuManager.ShowLevelFailedMenu(); // Mostrar el panel de nivel fallado
    }
}