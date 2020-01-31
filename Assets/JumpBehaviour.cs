using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    // Editor
    public float jumpVelocity = 15f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 10f;

    // Refs
    private Rigidbody2D rb;

    // State
    private bool jumpPressed = false;
    private bool holdingJump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
            holdingJump = true;
        }

        if(Input.GetButtonUp("Jump"))
        {
            holdingJump = false;
        }
    }

    private void FixedUpdate()
    {
        if(jumpPressed)
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if(rb.velocity.y > 0 && !holdingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        jumpPressed = false;
    }
}
