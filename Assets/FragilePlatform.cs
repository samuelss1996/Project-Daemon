using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    // Editor
    public float shakeTime;
    public float shakeSpeed;
    public float shakeStrength;

    public float fadeTime;
    public float restartTime;

    // Refs
    private SpriteRenderer sprite;

    // State
    private bool shouldFall;
    private bool allowCycleStart;
    private float timeSinceTouch;
    private Vector2 originalPos;
    private Color originalColor;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalPos = transform.position;
        originalColor = sprite.color;
        allowCycleStart = true;
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

                sprite.color = originalColor;
                transform.position = originalPos + new Vector2(currentShakePosX, currentShakePosY);
            }
            else if(timeSinceTouch <= shakeTime + fadeTime)
            {
                SetSmoothAlpha((timeSinceTouch - shakeTime) / fadeTime, true);
            }
            else if(timeSinceTouch <= shakeTime + fadeTime + restartTime)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if(timeSinceTouch <= shakeTime + 2 * fadeTime + restartTime)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                SetSmoothAlpha((timeSinceTouch - shakeTime - fadeTime - restartTime) / fadeTime, false);
                allowCycleStart = true;
            }
            else
            {
                shouldFall = false;
            }

            timeSinceTouch += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(allowCycleStart)
        {
            allowCycleStart = false;
            shouldFall = true;
            timeSinceTouch = 0;
        }
    }

    private void SetSmoothAlpha(float lerp, bool startOpaque)
    {
        float min = startOpaque ? 1 : 0;
        float max = startOpaque ? 0 : 1;

        float currentAlpha = Mathf.SmoothStep(min, max, lerp);
        Color currentColor = originalColor;
        currentColor.a = currentAlpha;

        sprite.color = currentColor;
    }
}
