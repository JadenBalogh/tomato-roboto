using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonDetector : MonoBehaviour
{
    [SerializeField] private Piston piston;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            piston.IsPlayerOver = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            piston.IsPlayerOver = false;
        }
    }
}
