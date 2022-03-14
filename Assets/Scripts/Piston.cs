using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : Interactable
{
    [SerializeField] private Animator topAnimator;
    [SerializeField] private float pushForce = 1f;
    [SerializeField] private float useDelay = 2f;

    public bool IsPlayerOver { get; set; }

    public override void Interact()
    {
        if (IsPlayerOver)
        {
            GameManager.Player.Rigidbody2D.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        }
        topAnimator.SetTrigger("Activate");
        Disable(useDelay);
    }
}
