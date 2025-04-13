using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productos_DropArea : MonoBehaviour, dropArea
{
    [SerializeField] private GameObject canvaMinigame;
    [SerializeField] private GameObject startObjetivo;
    [SerializeField] public int numObjetivos;
    private int completedGoals = 0;
    public void OnDropProd(minigame_Prod producto)
    {
        producto.transform.position = transform.position;
        completedGoals++;

        if (completedGoals == numObjetivos)
        {
            canvaMinigame.SetActive(false);
            startObjetivo.SetActive(false);
        }
    }

}
