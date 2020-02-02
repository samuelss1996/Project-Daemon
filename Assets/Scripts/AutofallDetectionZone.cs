using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofallDetectionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AutofallTriggerBehaviour>().StartMoving();
        }
    }
}
