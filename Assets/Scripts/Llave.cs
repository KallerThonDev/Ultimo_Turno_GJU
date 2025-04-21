using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
     public bool llaveActiva = false; // Variable booleana que cambiará a true

    public AudioClip soundKeys;

    private AudioSource audiosource;

    private void Start()
    {
        // Inicializar el AudioSource
        audiosource = GetComponent<AudioSource>();
        if (audiosource == null)
        {
            // Si no existe, añade uno automáticamente
            audiosource = gameObject.AddComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es el jugador
        if (other.CompareTag("Llave"))
        {
            llaveActiva = true; // Cambia el estado de la variable a true
            Debug.Log("Objeto activado por el jugador.");

            audiosource.PlayOneShot(soundKeys);
        }
    }
}
