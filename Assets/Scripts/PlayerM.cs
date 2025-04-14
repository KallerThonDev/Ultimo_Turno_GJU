using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Rigidbody rb;
    private Vector3 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Obtener inputs (WASD o flechas)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Crear vector de dirección
        inputDirection = new Vector3(horizontal, 0f, vertical);
    }

    void FixedUpdate()
    {
        // Mover el Rigidbody
        if (inputDirection.magnitude > 0.1f)
        {
            Vector3 movement = inputDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + transform.TransformDirection(movement));
        }
    }
}
