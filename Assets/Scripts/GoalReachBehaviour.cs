using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReachBehaviour : MonoBehaviour
{
    // Editor
    public float initialAnimVel;
    public float maxAnimVel;
    public float duration;

    // Refs
    private Rigidbody2D rb;
    private Animator animator;

    // State
    [HideInInspector]
    public bool shouldAttach = false;
    private float attachSpeed;
    private Vector2 targetPosition;
    private float animVel;
    private float animAcc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animVel = initialAnimVel;
        animAcc = (maxAnimVel - initialAnimVel) / duration;
    }

    private void Update()
    {
        if(shouldAttach)
        {
            float step = attachSpeed * Time.deltaTime; 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

            animator.SetFloat("xVelocity", animVel);
            animVel = Mathf.Min(animVel + animAcc * Time.deltaTime, maxAnimVel);
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
            FindObjectOfType<GoalBehaviour>().animate = true;
        }
    }
}
