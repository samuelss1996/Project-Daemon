using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatform : MonoBehaviour
{
    // Editor
    public bool state;

    // Refs
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        state = !state;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.enabled = state;
        collider.enabled = state;
    }

    public void Switch()
    {
        state = !state;
    }
}
