using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    [SerializeField] private float jumpBoostForce = 200f; // Fuerza de impulso
    [SerializeField] private float reducedMass = 0.5f; // Masa temporal reducida para el impulso
    [SerializeField] private float resetMassDelay = 0.5f; // Tiempo antes de restaurar la masa original

    private float originalMass; // Para almacenar la masa original del jugador

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRb = other.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            // Guarda la masa original
            originalMass = playerRb.mass;

            // Reduce la masa para aumentar el efecto del impulso
            playerRb.mass = reducedMass;

            // Opcional: Resetea la velocidad vertical antes de aplicar la fuerza
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);

            // Aplica una fuerza de impulso hacia arriba
            playerRb.AddForce(Vector3.up * jumpBoostForce, ForceMode.Impulse);

            // Restaura la masa original después de un breve retraso
            Invoke(nameof(ResetMass), resetMassDelay);
        }
    }

    private void ResetMass()
    {
        // Restaura la masa original del jugador
        Rigidbody playerRb = GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.mass = originalMass;
        }
    }
}
