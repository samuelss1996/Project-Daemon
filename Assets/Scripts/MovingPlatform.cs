﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Editor
    public Vector3 relativeEndPosition;
    public float periodLength;

    // State
    private Vector3 startPosition;
    private Transform previousPlayerParent;

    private void Awake()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float normalizedSpeed = Mathf.Sqrt(speed / relativeEndPosition.magnitude);
        float time = Camera.main.gameObject.GetComponent<AudioSource>().time;
        float currentLerp = -Mathf.Sin(2 * Mathf.PI * time / periodLength) * 0.5f + 0.5f;

        transform.position = Vector3.Lerp(startPosition, startPosition + relativeEndPosition, currentLerp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            previousPlayerParent = collision.gameObject.transform.parent;
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = previousPlayerParent;
        }
    }
}
