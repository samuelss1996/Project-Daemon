using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    // Editor
    public bool animate;
    public Color repairedColor;
    public float duration;

    // Refs
    private SpriteRenderer sprite;

    // State
    private Color originalColor;
    private float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(animate)
        {
            sprite.color = Color.Lerp(originalColor, repairedColor, Mathf.SmoothStep(0, 1, Mathf.Min(animationTime / duration, 1)));
            animationTime += Time.deltaTime;

            if(animationTime / duration >= 1)
            {
                FindObjectOfType<LevelDialogManager>().ShownEndDialog();
            }
        }
        else
        {
            animationTime = 0;
        }
    }
}
