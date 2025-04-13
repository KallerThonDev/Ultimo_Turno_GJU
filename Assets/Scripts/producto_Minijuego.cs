using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class producto_Minijuego : MonoBehaviour
{/*
    private Collider2D collider;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        startPos = transform.position;
        transform.position = GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private void OnMouseUp()
    {
        collider.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        collider.enabled = true;

        if (hitCollider != null && hitCollider.TryGetComponent(out dropArea dropArea))
        {
            dropArea.OnDropProd(this);
        }
        else
        {
            transform.position = startPos;
        }
    }

    public Vector3 GetMousePos()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }*/
}
