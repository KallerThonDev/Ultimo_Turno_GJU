using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_Objetivo : MonoBehaviour
{
    public Transform cam;
    private bool isPlayerNear = false;

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
        if (!isPlayerNear) return;

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
            isPlayerNear = true;
            marcaObjetivo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isPlayerNear = false;
            marcaObjetivo.SetActive(false);
        }
    }
}
