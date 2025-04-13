using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class minigame_Prod : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 startPos;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Guardamos la posici�n inicial
        startPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Aqu� podr�as poner feedback visual
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Movimiento con respecto al canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            // Verifica si fue soltado sobre un �rea v�lida
            GameObject target = eventData.pointerCurrentRaycast.gameObject;

            if (target != null && target.TryGetComponent(out dropArea dropArea))
            {
                dropArea.OnDropProd(this); // Llamada a tu l�gica
            }
            else
            {
                // Si no es v�lido, vuelve a la posici�n original
                rectTransform.anchoredPosition = startPos;
            }
        
    }
}
