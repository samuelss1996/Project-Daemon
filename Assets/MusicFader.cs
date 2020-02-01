using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    // Editor
    public float fadeInTime;
    public float fadeOutTime;

    // Refs
    private AudioSource music;

    // State
    private float fadeTime;
    private float currentTime;
    private float startVolume = 0;
    private float endVolume = 0;

    // Start is called before the first frame update
    void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = Mathf.SmoothStep(startVolume, endVolume, currentTime / fadeInTime);
        currentTime += Time.deltaTime;
    }

    public void FadeIn()
    {
        Fade(0, 1, fadeInTime);
        music.Play();
    }

    public void FadeOut()
    {
        Fade(1, 0, fadeOutTime);
    }

    private void Fade(float start, float end, float _fadeTime)
    {
        startVolume = start;
        endVolume = end;
        fadeTime = _fadeTime;

        currentTime = 0;
    }
}
