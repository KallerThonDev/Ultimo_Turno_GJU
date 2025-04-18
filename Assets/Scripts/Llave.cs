using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
     public bool llaveActiva = false; // Variable booleana que cambiará a true

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es el jugador
        if (other.CompareTag("Llave"))
        {
            llaveActiva = true; // Cambia el estado de la variable a true
            Debug.Log("Objeto activado por el jugador.");

        }
    }
}
