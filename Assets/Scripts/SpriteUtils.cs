using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUtils
{
    public static void SetSmoothAlpha(SpriteRenderer sprite, Color originalColor, float lerp, bool startOpaque)
    {
        float min = startOpaque ? 1 : 0;
        float max = startOpaque ? 0 : 1;

        float currentAlpha = Mathf.SmoothStep(min, max, lerp);
        Color currentColor = originalColor;
        currentColor.a = currentAlpha;

        sprite.color = currentColor;
    }
}
