using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo_Gerente : MonoBehaviour
{
    [SerializeField] private GameObject canvaDialogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            canvaDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
           canvaDialogo.gameObject.SetActive(false);
        }
    }
}
