using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Exit : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        // Asegúrate de que el botón esté asignado
        if (exitButton != null)
        {
            // Asocia la función que se llamará al hacer clic en el botón
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }
    }

    // Función llamada cuando se presiona el botón "Exit"
    void OnExitButtonClicked()
    {
        // Si estamos en el editor de Unity, detendremos el juego
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        
#endif
    }
}
