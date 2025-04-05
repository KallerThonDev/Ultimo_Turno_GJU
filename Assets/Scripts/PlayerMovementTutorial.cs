using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Se importa TextMeshPro (aunque no se usa en este script)

// Definición de la clase PlayerMovementTutorial, que hereda de MonoBehaviour
public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")] // Agrupa las siguientes variables en el Inspector bajo "Movement"
    public float moveSpeed; // Velocidad de movimiento del jugador
    public float groundDrag; // Resistencia/fricción cuando está en el suelo
    public float jumpForce; // Fuerza de salto
    public float jumpCooldown; // Tiempo de espera entre saltos
    public float airMultiplier; // Multiplicador de velocidad en el aire
    bool readyToJump; // Indica si el jugador está listo para saltar

    [HideInInspector] public float walkSpeed; // Velocidad de caminar (no se usa en el código)
    [HideInInspector] public float sprintSpeed; // Velocidad de correr (no se usa en el código)

    [Header("Keybinds")] // Agrupa las siguientes variables en el Inspector bajo "Keybinds"
    public KeyCode jumpKey = KeyCode.Space; // Tecla asignada para saltar

    [Header("Ground Check")] // Agrupa las siguientes variables en el Inspector bajo "Ground Check"
    public float playerHeight; // Altura del jugador para el chequeo de suelo
    public LayerMask whatIsGround; // Capa que se considera como suelo
    bool grounded; // Indica si el jugador está tocando el suelo

    public Transform orientation; // Transform para la orientación del movimiento

    float horizontalInput; // Entrada del eje horizontal (A/D o flechas)
    float verticalInput; // Entrada del eje vertical (W/S o flechas)

    Vector3 moveDirection; // Dirección del movimiento

    Rigidbody rb; // Referencia al Rigidbody del jugador

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene la referencia del Rigidbody
        rb.freezeRotation = true; // Evita que el Rigidbody rote automáticamente

        readyToJump = true; // Inicializa la variable para permitir saltar
    }

    private void Update()
    {
        // Verifica si el jugador está en el suelo usando un Raycast hacia abajo
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput(); // Llama a la función para manejar la entrada del jugador
        SpeedControl(); // Llama a la función para controlar la velocidad

        // Aplica la resistencia/fricción solo cuando el jugador está en el suelo
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Mueve al jugador en cada frame de física
    }

    private void MyInput()
    {
        // Obtiene la entrada del jugador en los ejes horizontal y vertical
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer()
    {
        // Calcula la dirección del movimiento según la orientación y entrada del jugador
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Si el jugador está en el suelo, se mueve con fuerza normal
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // Si el jugador está en el aire, se mueve con un multiplicador de velocidad
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // Obtiene la velocidad actual del jugador en el plano horizontal
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limita la velocidad si excede el límite definido por moveSpeed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // Calcula la velocidad limitada
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // Aplica la velocidad limitada
        }
    }

    private void Jump()
    {
        // Resetea la velocidad vertical para hacer saltos consistentes
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Aplica la fuerza de salto hacia arriba
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true; // Habilita el salto nuevamente después del cooldown
    }
}
