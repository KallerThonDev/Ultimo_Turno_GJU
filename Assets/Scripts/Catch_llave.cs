using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_llave : MonoBehaviour
{
    public GameObject LlavePrefab;
    public bool llaveInventario = false; // Variable booleana que cambiará a true

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es el jugador
        if (other.CompareTag("player"))
        {
            llaveInventario = true; // Cambia el estado de la variable a true
            Debug.Log("Objeto activado por el jugador.");
            Destroy(LlavePrefab);
        }
    }
}
