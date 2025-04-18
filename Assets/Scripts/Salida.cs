using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
     public Llave objectTrigger; // Referencia al script ObjectTrigger

    [SerializeField] private GameObject marcaObjetivo;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en la zona es el jugador
        if (other.CompareTag("player"))
        {
            // Si el objeto ya ha sido activado, carga la escena del menú
            if (objectTrigger != null && objectTrigger.llaveActiva)
            {
                Debug.Log("Acceso permitido. Cargando menú...");
                SceneManager.LoadScene("MainMenu"); // Cambia "Menu" por el nombre real de tu escena
            }
            else
            {
                Debug.Log("No puedes acceder aún.");
                marcaObjetivo.SetActive(true);
            }
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
