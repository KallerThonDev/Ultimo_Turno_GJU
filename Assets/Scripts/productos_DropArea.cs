using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productos_DropArea : MonoBehaviour, dropArea
{

    [SerializeField] private GameObject filter;
    [SerializeField] private GameObject startObjetivo, finObjetivo;
    [SerializeField] public int numObjetivos;
    private int completedGoals = 0;
    public void OnDropProd(minigame_Prod producto)
    {
        producto.transform.position = transform.position;
        completedGoals++;

        if (completedGoals == numObjetivos)
        {
            Canvas[] allCanvases = FindObjectsOfType<Canvas>();

            foreach (Canvas canvas in allCanvases)
            {
                canvas.gameObject.SetActive(false);
                filter.SetActive(true);
            }
            startObjetivo.SetActive(false);
            finObjetivo.SetActive(true);
        }
    }

}
