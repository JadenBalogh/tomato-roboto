using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] private LayerMask interactMask;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D col = Physics2D.OverlapPoint(mousePos, interactMask);
        
        Interactable target = null;
        if (col != null && col.TryGetComponent<Interactable>(out target))
        {
            target.IsHovering = true;
        }

        if (target != null && Input.GetButtonDown("Fire1"))
        {
            target.Interact();
        }
    }
}
