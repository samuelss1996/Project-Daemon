using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReachBehaviour : MonoBehaviour
{    
    // Refs
    private Rigidbody2D rb;

    // State
    private bool shouldAttach = false;
    private float attachSpeed;
    private Vector2 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(shouldAttach)
        {
            float step = attachSpeed * Time.deltaTime; 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal") && !shouldAttach)
        {
            attachSpeed = rb.velocity.magnitude;
            shouldAttach = true;
            targetPosition = collision.transform.position;

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
