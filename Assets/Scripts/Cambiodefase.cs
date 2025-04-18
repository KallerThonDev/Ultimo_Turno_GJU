using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodefase : MonoBehaviour
{
    public string sceneToLoad = "NombreDeLaEscenaDestino";

    // Tareas a completar
    public bool taskACompleted = false;
    public bool taskBCompleted = false;
    public bool taskCCompleted = false;

    // Singleton temporal para mantener el estado entre escenas
    public static bool goToSpawnPoint = false;

    void Update()
    {
        if (taskACompleted && taskBCompleted && taskCCompleted)
        {
            goToSpawnPoint = true; // Indicamos que el jugador debe ir al punto de spawn
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Esto se ejecuta cuando la nueva escena ha cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (goToSpawnPoint)
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject spawnPoint = GameObject.FindWithTag("Respawn"); // El punto debe tener esta etiqueta

            if (player != null && spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
                Debug.Log("✅ Jugador reposicionado en el punto de aparición.");
            }
            else
            {
                Debug.LogWarning("⚠️ No se encontró el jugador o el punto de aparición.");
            }

            goToSpawnPoint = false;
        }

        // Importante: desuscribimos el evento para evitar llamadas múltiples
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
