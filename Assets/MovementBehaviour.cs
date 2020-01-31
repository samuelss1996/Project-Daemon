using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    // Editor
    public float maxSpeed;

    // Refs
    private Animator animator;

    // State
    private float axis;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(FindObjectOfType<DialogUI>()?.isFinsihed ?? true)
        {
            axis = Input.GetAxis("Horizontal");
        }
        else
        {
            axis = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
        currentVelocity.x = axis * maxSpeed;

        GetComponent<Rigidbody2D>().velocity = currentVelocity;

        animator.SetFloat("xVelocity", currentVelocity.x);
    }
}
