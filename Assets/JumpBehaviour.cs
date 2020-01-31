using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBehaviour : MonoBehaviour
{
    // Editor
    public float jumpVelocity = 15f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 10f;
    public float coyoteTime;

    public Text coyoteDebug;

    // Refs
    private Rigidbody2D rb;
    private GroundCheck gCheck;

    // State
    private bool jumpPressed = false;
    private bool holdingJump = false;
    private bool previouslyGrounded = false;
    private bool canCoyote = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gCheck = GetComponent<GroundCheck>();
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

        coyoteDebug.text = $"Coyote: {canCoyote}";
    }

    private void FixedUpdate()
    {
        if(previouslyGrounded && !gCheck.grounded)
        {
            StartCoroutine(CoyoteTimeCR());
        }

        if(jumpPressed && CanJump())
        {
            rb.velocity = Vector2.up * jumpVelocity;
            canCoyote = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if(rb.velocity.y > 0 && !holdingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        previouslyGrounded = gCheck.grounded;
        gCheck.grounded = false;
        jumpPressed = false;
    }

    private IEnumerator CoyoteTimeCR()
    {
        canCoyote = true;
        yield return new WaitForSeconds(coyoteTime);
        canCoyote = false;
    }

    private bool CanJump()
    {
        bool controlsEnabled = (FindObjectOfType<DialogUI>()?.isFinsihed ?? true);

        return controlsEnabled && (gCheck.grounded || canCoyote);
    }
}
