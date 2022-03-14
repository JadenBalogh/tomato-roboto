using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float minVelocityX = 2f;
    [SerializeField] private float deathHeight = -7f;

    private int moveDir = 1;

    public Rigidbody2D Rigidbody2D { get; private set; }

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        spriteRenderer.flipX = moveDir < 0;

        Rigidbody2D.velocity = new Vector2(Mathf.Max(minVelocityX, Rigidbody2D.velocity.x) * moveDir, Rigidbody2D.velocity.y);

        if (transform.position.y < deathHeight)
        {
            GameManager.EndGame(false);
        }
    }

    public void LookAt(Transform target)
    {
        moveDir = Mathf.RoundToInt(Mathf.Sign(target.position.x - transform.position.x));
    }
}
