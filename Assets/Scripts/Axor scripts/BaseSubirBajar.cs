using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSubirBajar : MonoBehaviour
{

    public float speed = 2f; // Velocidad de movimiento
    public float height = 3f; // Altura máxima de movimiento

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la posición en el eje Y para que la plataforma suba y baje de forma oscilante
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
