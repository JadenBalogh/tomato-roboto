using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBox : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right);
        if (hitR && hitR.collider.CompareTag("Player"))
        {
            GameManager.Player.LookAt(transform);
        }
        
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left);
        if (hitL && hitL.collider.CompareTag("Player"))
        {
            GameManager.Player.LookAt(transform);
        }
    }
}
