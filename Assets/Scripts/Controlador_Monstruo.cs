using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Controlador_Monstruo : MonoBehaviour
{
    public GameObject entityPrefab; // Prefab de la entidad a spawnear
    public Transform player; // Referencia al jugador
    public float minSpawnDistance = 5f; // Distancia mínima de spawn
    public float maxSpawnDistance = 10f; // Distancia máxima de spawn

    public float waitTime = 5f; // Tiempo de espera antes de spawnear
    public float stayTime = 5f; // Tiempo que permanece la entidad en la escena
    public float maxDistanceFromPlayer = 15f; // Distancia máxima que el jugador puede alejarse de la entidad antes de que desaparezca
    public float maxDistanceClosePlayer;

    private GameObject currentEntity; // Referencia a la entidad que está actualmente en la escena

    private void Start()
    {
        StartCoroutine(SpawnCycle()); // Inicia el ciclo de spawn
    }

    // Función que controla el ciclo de spawn y desaparición de la entidad
    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime); // Espera el tiempo de espera
            SpawnEntity(); // Spawnea la entidad
            yield return new WaitForSeconds(stayTime); // Espera el tiempo de permanencia

            // Aquí puedes agregar el código para eliminar o desactivar la entidad
            if (currentEntity != null)
            {
                Debug.Log("Entidad desaparecida.");
                Destroy(currentEntity); // Elimina la entidad actual
            }
        }
    }

    private void SpawnEntity()
    {
        // Obtener una posición válida alrededor del jugador
        Vector3 spawnPosition = GetSpawnPosition();

        // Instanciar el prefab en la posición calculada
        currentEntity = Instantiate(entityPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("🎭 Entidad spawneada en: " + spawnPosition);

        // Iniciar el chequeo de distancia en segundo plano
        StartCoroutine(CheckDistance());
    }

    private Vector3 GetSpawnPosition()
    {
        // Generar una distancia aleatoria entre min y max para la distancia desde el jugador
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Generar un ángulo aleatorio entre 0 y 360 grados
        float angle = Random.Range(0f, 360f);

        // Calcular las coordenadas de la posición final usando el ángulo y la distancia
        float spawnX = player.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * randomDistance;
        float spawnZ = player.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * randomDistance;

        // La altura (Y) permanece igual a 0
        Vector3 spawnPosition = new Vector3(spawnX, 0, spawnZ);

        Debug.Log("Posición generada: " + spawnPosition);
        return spawnPosition;
    }

    // Corutina para verificar la distancia entre el jugador y la entidad
    private IEnumerator CheckDistance()
    {
        while (currentEntity != null)
        {
            // Comprobamos la distancia entre el jugador y la entidad
            float distance = Vector3.Distance(player.position, currentEntity.transform.position);

            // Si la distancia es mayor que la distancia máxima, destruimos la entidad
            if (distance > maxDistanceFromPlayer)
            {
                Debug.Log("La entidad ha desaparecido porque el jugador está demasiado lejos.");
                Destroy(currentEntity); // Destruye la entidad
                break; // Salimos del bucle para evitar seguir comprobando
            }
            if (distance < maxDistanceClosePlayer)
            {
                Debug.Log("La entidad ha desaparecido porque el jugador está demasiado cerca.");
                Destroy(currentEntity); // Destruye la entidad
                break; // Salimos del bucle para evitar seguir comprobando
            }

            // Espera un breve tiempo antes de comprobar de nuevo
            yield return new WaitForSeconds(0.5f); // Ajusta el intervalo de tiempo de verificación según lo necesites
        }
    }
}
