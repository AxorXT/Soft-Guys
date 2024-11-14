using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLados : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public Transform objectToMove; // Objeto a mover
        public Transform pointA;       // Primer punto de destino
        public Transform pointB;       // Segundo punto de destino
        public float speed = 2f;       // Velocidad de movimiento
        [HideInInspector] public float t = 0f;  // Variable de interpolación
        [HideInInspector] public bool movingToB = true; // Dirección de movimiento
    }

    public List<MovableObject> objectsToMove; // Lista de objetos a mover

    void Update()
    {
        // Itera a través de cada objeto en la lista
        foreach (var movableObject in objectsToMove)
        {
            // Movimiento hacia el punto B
            if (movableObject.movingToB)
            {
                movableObject.t += Time.deltaTime * movableObject.speed;
                if (movableObject.t >= 1f)
                {
                    movableObject.t = 1f;
                    movableObject.movingToB = false; // Cambiar dirección
                }
            }
            else // Movimiento hacia el punto A
            {
                movableObject.t -= Time.deltaTime * movableObject.speed;
                if (movableObject.t <= 0f)
                {
                    movableObject.t = 0f;
                    movableObject.movingToB = true; // Cambiar dirección
                }
            }

            // Interpolación de posición entre pointA y pointB
            if (movableObject.objectToMove != null && movableObject.pointA != null && movableObject.pointB != null)
            {
                movableObject.objectToMove.position = Vector3.Lerp(movableObject.pointA.position, movableObject.pointB.position, movableObject.t);
            }
        }
    }
}
