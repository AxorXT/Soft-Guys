using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f; // Multiplicador de velocidad de sprint
    public float groundDrag = 6f;

    public float jumpForce = 5f;
    public float jumpCooldown;
    public float airMultiplier = 0.4f;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift; // Tecla para activar el sprint

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Nueva variable para saber si el jugador está sobre una plataforma
    private Transform platform;
    private Vector3 platformOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        walkSpeed = moveSpeed;
        sprintSpeed = moveSpeed * sprintMultiplier;
    }

    private void Update()
    {
        // Verificar si el jugador está tocando el suelo
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        // Obtener las entradas de movimiento
        MyInput();

        // Controlar la velocidad y aplicar el freno
        SpeedControl();

        // Aplicar drag (resistencia) cuando el jugador está en el suelo
        if (grounded)
            rb.drag = groundDrag; // Ajustar el valor de drag para evitar el deslizamiento
        else
            rb.drag = 0; // Sin drag en el aire
    }

    private void FixedUpdate()
    {
        // Mover al jugador en función de la entrada
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Salto
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // Cambio de velocidad para sprint
        if (Input.GetKey(sprintKey) && grounded)
            moveSpeed = sprintSpeed;
        else
            moveSpeed = walkSpeed;
    }

    private void MovePlayer()
    {
        // Calcular la dirección del movimiento basada en la entrada
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Si el jugador está sobre una plataforma, ajustar el movimiento
        if (platform != null)
        {
            // Mantener la posición relativa del jugador respecto a la plataforma
            Vector3 platformMovement = platform.position - platformOffset;

            // Mover al jugador junto con la plataforma
            rb.position += platformMovement;
            platformOffset = platform.position;
        }

        // Mover al jugador si está en el suelo
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 5f * airMultiplier, ForceMode.Force); // Menor fuerza en el aire
    }

    private void SpeedControl()
    {
        // Solo considerar el movimiento en el plano horizontal (sin la componente Y)
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limitar la velocidad máxima si excede la velocidad deseada
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Evitar que el jugador mantenga la velocidad en el eje Y cuando salta
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Aplicar fuerza de salto
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform = collision.transform;  // Asignar la plataforma
            platformOffset = platform.position; // Guardar la posición inicial de la plataforma
        }
    }

    // Cuando el jugador deja de estar sobre la plataforma
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform = null;  // Limpiar la referencia a la plataforma
        }
    }
}
