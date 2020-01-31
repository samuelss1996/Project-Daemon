using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundCheck : MonoBehaviour
{
    public Text debug;

    // State
    private bool grounded = false;

    private void Update()
    {
        debug.text = $"Grounded: {grounded}";
    }

    private void FixedUpdate()
    {
        grounded = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
        }

        Debug.Log("Hi");
    }
}
