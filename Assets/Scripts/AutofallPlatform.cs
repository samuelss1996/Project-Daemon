using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofallPlatform : MonoBehaviour
{
    // Editor
    public static float startTime = 3f;
    public static float spacingTime = 0.2f;
    public static float animationTime = 0.2f;
    public static float fallDownDistance = 0.2f;

    // Refs
    private SpriteRenderer sprite;

    // State
    private Vector2 originalPos;
    private Color originalColor;
    private bool fall;
    private float currentTime;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalPos = transform.position;
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        /*float currentAnimationTime = Time.time - (startTime + index * spacingTime);
        if (currentAnimationTime >= 0)
        {
            float animTimeNormalized = currentAnimationTime / animationTime;

            if(animTimeNormalized >= 1)
            {
                gameObject.SetActive(false);
                return;
            }

            SpriteUtils.SetSmoothAlpha(sprite, originalColor, animTimeNormalized, true);
            //transform.position = Vector3.Slerp(originalPos, originalPos + fallDownDistance * Vector2.down, animTimeNormalized);
        }*/

        if(fall)
        {
            float animTimeNormalized = currentTime / animationTime;

            if (animTimeNormalized >= 1)
            {
                gameObject.SetActive(false);
                return;
            }

            SpriteUtils.SetSmoothAlpha(sprite, originalColor, animTimeNormalized, true);

            currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("AutofallTrigger"))
        {
            fall = true;
        }
    }
}
