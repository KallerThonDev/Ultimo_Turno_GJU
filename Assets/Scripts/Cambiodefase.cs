using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Cambiodefase : MonoBehaviour
{
    public string sceneToLoad = "Fasa2_Mapa";
    public float timeToWait = 10f;  // Tiempo de espera en segundos
    private Coroutine countdownCoroutine;

    // Tareas a completar
    public bool taskACompleted = false;
    public bool taskBCompleted = false;

    // Singleton temporal para mantener el estado entre escenas
    public static bool goToSpawnPoint = false;

    public AudioClip scareSound;
    public Image blackScreen; // Imagen negra (UI Canvas)
    public float flickerDuration = 0.5f; // Duración de cada parpadeo
    public int flickerCount = 3; // Número de parpadeos

    private AudioSource audioSource;
    private static GameObject persistentCanvasInstance;

    private void Awake()
    {
        // Inicializar AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    void OnEnable()
    {
        // Suscribirse al evento
        productos_DropArea.OnTaskCompleted += HandleTaskCompleted;
    }

    void OnDisable()
    {
        // Desuscribirse para evitar memory leaks
        productos_DropArea.OnTaskCompleted -= HandleTaskCompleted;
    }

    private void HandleTaskCompleted(string taskName)
    {
        // Marca la tarea correspondiente como completada
        if (taskName == "areaFin1")
        {
            taskACompleted = true;
        }
        else if (taskName == "areaFin2")
        {
            taskBCompleted = true;
        }

        // Verifica si todas las tareas están completadas
        CheckAllTasksCompleted();
    }

    private void CheckAllTasksCompleted()
    {
        if (taskACompleted && taskBCompleted)
        {
            goToSpawnPoint = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
            countdownCoroutine = StartCoroutine(SceneChangeCountdown());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Esto se ejecuta cuando la nueva escena ha cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (goToSpawnPoint)
        {
            GameObject player = GameObject.FindWithTag("player");
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

    private IEnumerator SceneChangeCountdown()
    {
        Debug.Log("⏳ Tarea iniciada. Cambiando escena en " + timeToWait + " segundos...");
        yield return new WaitForSeconds(timeToWait);
        // Activa el efecto de parpadeo antes de cargar la escena
        yield return StartCoroutine(FlickerBlackScreen());
        Debug.Log("✅ Tiempo cumplido. Cargando escena...");
        SceneManager.LoadScene(sceneToLoad);
    }

    // Corrutina para el efecto de parpadeo
    private IEnumerator FlickerBlackScreen()
    {
        if (blackScreen == null || audioSource == null)
        {
            Debug.LogError("⚠️ Faltan referencias en el Inspector!");
            yield break;
        }

        // Configurar pantalla negra
        var canvas = blackScreen.transform.root.gameObject;
        blackScreen.gameObject.SetActive(true);
        blackScreen.color = Color.black;

        // Reproducir sonido
        if (scareSound != null)
        {
            audioSource.PlayOneShot(scareSound);
        }

        // Efecto de parpadeo
        for (int i = 0; i < flickerCount; i++)
        {
            blackScreen.color = new Color(0, 0, 0, 1);
            yield return new WaitForSeconds(flickerDuration);
            blackScreen.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(flickerDuration);
        }

        blackScreen.color = new Color(0, 0, 0, 1);
    }
}
