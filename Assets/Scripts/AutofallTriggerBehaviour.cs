using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofallTriggerBehaviour : MonoBehaviour
{
    // Editor
    public float velocity;

    public void StartMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
    }
}
