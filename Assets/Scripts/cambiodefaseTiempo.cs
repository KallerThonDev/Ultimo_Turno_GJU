using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiodefaseTiempo : MonoBehaviour
{
     public string sceneToLoad;       // Nombre de la escena a la que se cambiará
    public float timeToWait = 30f;  // Tiempo de espera en segundos (5 minutos)
    
    private bool taskActive = false; // Controla si el temporizador está activo
    private Coroutine countdownCoroutine;

    void Update()
    {
        // Puedes activar la tarea presionando una tecla para probar (por ejemplo, T)
        if (Input.GetKeyDown(KeyCode.T) && !taskActive)
        {
            StartSceneChangeTask();
        }
    }

    public void StartSceneChangeTask()
    {
        if (!taskActive)
        {
            taskActive = true;
            countdownCoroutine = StartCoroutine(SceneChangeCountdown());
        }
    }

    public void CancelSceneChangeTask()
    {
        if (taskActive)
        {
            StopCoroutine(countdownCoroutine);
            taskActive = false;
            Debug.Log("🚫 Tarea cancelada.");
        }
    }

    private IEnumerator SceneChangeCountdown()
    {
        Debug.Log("⏳ Tarea iniciada. Cambiando escena en " + timeToWait + " segundos...");
        yield return new WaitForSeconds(timeToWait);
        Debug.Log("✅ Tiempo cumplido. Cargando escena...");
        SceneManager.LoadScene(sceneToLoad);
    }
}
