using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class productos_DropArea : MonoBehaviour, dropArea
{

    [SerializeField] private GameObject canvaMinigame;
    [SerializeField] private GameObject startObjetivo, finObjetivo;
    [SerializeField] public int numObjetivos;
    private int completedGoals = 0;

    // Evento estático para notificar la finalización
    public static event Action<string> OnTaskCompleted;

    public void OnDropProd(minigame_Prod producto)
    {
        producto.transform.position = transform.position;
        completedGoals++;

        if (completedGoals == numObjetivos)
        {
            canvaMinigame.SetActive(false);
            startObjetivo.SetActive(false);
            finObjetivo.SetActive(true);
            // Notifica que la tarea está completada (usa el nombre del objeto como identificador)
            OnTaskCompleted?.Invoke(gameObject.name);
        }
    }

}
