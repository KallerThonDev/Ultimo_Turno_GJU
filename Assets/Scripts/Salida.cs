using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
     public Llave objectTrigger; // Referencia al script ObjectTrigger

    [SerializeField] private GameObject marcaObjetivo;
    public AudioClip soundPuerta;
    public GameObject blackscreenFin;

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
        // Verifica si el objeto que entra en la zona es el jugador
        if (other.CompareTag("player"))
        {
            // Si el objeto ya ha sido activado, carga la escena del menú
            if (objectTrigger != null && objectTrigger.llaveActiva)
            {
                Debug.Log("Acceso permitido. Cargando menú...");
                
                // Detener todos los audios antes de reproducir el nuevo
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource audio in allAudioSources)
                {
                    audio.Stop();
                }
                StartCoroutine(LoadMenuWithCountdown(4f));
                blackscreenFin.gameObject.SetActive(true); // Enciende la pantalla
                audiosource.PlayOneShot(soundPuerta);

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

    private IEnumerator LoadMenuWithCountdown(float delay)
    {
        float timer = delay;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null; // Espera un frame
        }

        SceneManager.LoadScene("MainMenu");
    }
}
