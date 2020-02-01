using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    // Editor
    public float fadeTime;

    // Refs
    private Image image;

    // State
    private Color start = Color.clear;
    private Color end = Color.clear;
    private float currentTime;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.color = Color.Lerp(start, end, Mathf.SmoothStep(0, 1, currentTime / fadeTime));
        currentTime += Time.deltaTime;
    }

    public void FadeIn()
    {
        Fade(Color.black, Color.clear);
    }

    public void FadeOut()
    {
        Fade(Color.clear, Color.black);
    }

    private void Fade(Color _start, Color _end)
    {
        start = _start;
        end = _end;

        currentTime = 0;
    }
}
