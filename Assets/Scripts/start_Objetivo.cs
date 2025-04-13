using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_Objetivo : MonoBehaviour
{
    public Transform cam;


    [SerializeField] private GameObject objetivo;
    [SerializeField] private GameObject marcaObjetivo;
    [SerializeField] private GameObject canvaMinigame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycast;
            if(Physics.Raycast(cam.position, cam.forward, out raycast, 2.0f))
            {
                canvaMinigame.SetActive(true); //Comenzar minijuego

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            marcaObjetivo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            marcaObjetivo.SetActive(false);
        }
    }
}
