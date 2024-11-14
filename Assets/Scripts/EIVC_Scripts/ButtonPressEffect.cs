using System.Collections;  // Asegúrate de importar System.Collections
using UnityEngine;

public class ButtonPressEffect : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 pressedScale = new Vector3(0.9f, 0.9f, 0.9f); // Escala cuando el botón se presiona
    public float pressDuration = 0.1f; // Duración de la presión

    void Start()
    {
        originalScale = transform.localScale;  // Guarda la escala original del botón
    }

    // Se llama cuando otro objeto entra en el área del collider (Trigger)
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entró es el personaje (puedes usar un tag o nombre de objeto)
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();  // Detenemos cualquier corutina en curso
            StartCoroutine(PressButton());  // Llamamos a la corutina para presionar el botón
        }
    }

    // Se llama cuando el objeto sale del área del collider (Trigger)
    void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que salió es el personaje
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;  // Restauramos el tamaño original
        }
    }

    // Corutina que cambia la escala del botón temporalmente para simular el efecto de presión
    IEnumerator PressButton()
    {
        transform.localScale = pressedScale;  // Reducimos el tamaño para simular la presión
        yield return new WaitForSeconds(pressDuration);  // Esperamos un breve momento
        transform.localScale = originalScale;  // Restauramos el tamaño original
    }
}
