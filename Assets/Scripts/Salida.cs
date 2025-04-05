using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
     public Llave objectTrigger; // Referencia al script ObjectTrigger

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en la zona es el jugador
        if (other.CompareTag("Player"))
        {
            // Si el objeto ya ha sido activado, carga la escena del menú
            if (objectTrigger != null && objectTrigger.llaveActiva)
            {
                Debug.Log("Acceso permitido. Cargando menú...");
                SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre real de tu escena
            }
            else
            {
                Debug.Log("No puedes acceder aún.");
            }
        }
    }
}
