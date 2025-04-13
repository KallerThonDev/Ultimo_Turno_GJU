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
        // Guardamos la posición inicial
        startPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Aquí podrías poner feedback visual
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Movimiento con respecto al canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            // Verifica si fue soltado sobre un área válida
            GameObject target = eventData.pointerCurrentRaycast.gameObject;

            if (target != null && target.TryGetComponent(out dropArea dropArea))
            {
                dropArea.OnDropProd(this); // Llamada a tu lógica
            }
            else
            {
                // Si no es válido, vuelve a la posición original
                rectTransform.anchoredPosition = startPos;
            }
        
    }
}
