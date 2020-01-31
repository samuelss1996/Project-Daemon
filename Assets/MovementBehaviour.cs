using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    // Editor
    public float maxSpeed;

    // State
    private float axis;


    void Update()
    {
        axis = Input.GetAxis("Horizontal");
        Debug.Log(axis);
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
        currentVelocity.x = axis * maxSpeed;

        GetComponent<Rigidbody2D>().velocity = currentVelocity;
    }
}
