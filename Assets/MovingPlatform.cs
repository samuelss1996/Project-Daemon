using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Editor
    public Vector3 relativeEndPosition;
    public float speed;

    // State
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedSpeed = Mathf.Sqrt(speed / relativeEndPosition.magnitude);
        float currentLerp = -Mathf.Cos(Time.time * normalizedSpeed) * 0.5f + 0.5f;

        transform.position = Vector3.Lerp(startPosition, startPosition + relativeEndPosition, currentLerp);
    }
}
