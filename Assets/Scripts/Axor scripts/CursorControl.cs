using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    public Camera playerCamera;  // La cámara desde donde se realiza el raycast.
    public GameObject buttonObject;  // El botón o el objeto con el que interactuar.

    // Start is called before the first frame update
    void Start()
    {
        // Mueve el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor.
        Cursor.visible = true;  // Asegura que el cursor esté visible.
        CenterCursor();  // Mueve el cursor al centro de la pantalla al iniciar.
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador hace clic, se interactúa con el objeto en el centro de la pantalla.
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo del ratón
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));  // Lanza un raycast desde el centro de la pantalla.

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == buttonObject)  // Si el raycast impacta el botón.
                {
                    Debug.Log("¡Botón presionado!");
                    // Aquí puedes agregar el código para la acción del botón, como iniciar un cronómetro.
                }
            }
        }
    }

    // Método para centrar el puntero en la pantalla.
    void CenterCursor()
    {
        // Establece la posición del puntero en el centro de la pantalla.
        Cursor.SetCursor(null, new Vector2(Screen.width / 2, Screen.height / 2), CursorMode.Auto);
    }
}
