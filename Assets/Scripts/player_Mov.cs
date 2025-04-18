using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Mov : MonoBehaviour
{
    private Rigidbody player;
    private float hMove, vMove;
    private Vector3 playerInput;
    private Vector3 playerDirection;
    public float speed;

    public Camera mainCam;
    private Vector3 camForward;
    private Vector3 camRight;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        player.AddForce(playerDirection * speed);
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(hMove, 0, vMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1); //Magnitud de movimiento limitada a 1 (movimiento diagonal)

        camDirection(); //Obtener direccion de la camara horizontal

        playerDirection = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + playerDirection);

    }

    void camDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}