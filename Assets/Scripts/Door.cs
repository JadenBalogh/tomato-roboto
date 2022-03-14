using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private float moveOffset = 3f;
    [SerializeField] private float moveSpeed = 1f;

    private Vector3 targetPos;
    private bool isMoving = false;

    protected override void Start()
    {
        base.Start();

        targetPos = transform.position + Vector3.up * moveOffset;
    }

    protected override void Update()
    {
        base.Update();

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public override void Interact()
    {
        isMoving = true;
        Disable();
    }
}
