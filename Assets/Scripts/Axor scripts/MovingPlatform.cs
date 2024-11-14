using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right; // Dirección de movimiento
    public float moveDistance = 5f;               // Distancia de movimiento
    public float moveSpeed = 2f;                  // Velocidad de movimiento

    private Vector3 startPosition;
    private bool movingForward = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Movimiento de la plataforma
        float movement = moveSpeed * Time.deltaTime;
        if (movingForward)
            transform.Translate(moveDirection * movement);
        else
            transform.Translate(-moveDirection * movement);

        // Cambiar de dirección al alcanzar la distancia máxima
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingForward = !movingForward;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hacer que el jugador sea hijo de la plataforma
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remover el jugador como hijo de la plataforma
            collision.transform.SetParent(null);
        }
    }
}