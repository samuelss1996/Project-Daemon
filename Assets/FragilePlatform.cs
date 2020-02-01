using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    // Editor
    public float shakeTime;
    public float shakeSpeed;
    public float shakeStrength;

    // State
    private bool shouldFall;
    private float timeSinceTouch;
    private Vector2 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFall)
        {
            if (timeSinceTouch <= shakeTime)
            {
                float currentShakePosX = Mathf.Sin(timeSinceTouch * shakeSpeed) * shakeStrength;
                float currentShakePosY = (Mathf.Cos(timeSinceTouch * shakeSpeed * 1.3f) - 1) * shakeStrength / 2;

                transform.position = originalPos + new Vector2(currentShakePosX, currentShakePosY);
            }

            timeSinceTouch += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!shouldFall)
        {
            shouldFall = true;
            timeSinceTouch = 0;
        }
    }
}
