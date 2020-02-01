using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatformManager : MonoBehaviour
{
    public int bpm;
    public int ticksPerCompass;
    public AudioSource music;

    // State
    private bool changePending = true;

    private void Update()
    {
        float tickTime = 1 / (bpm / 60.0f);
        int currentTick = Mathf.FloorToInt(music.time / tickTime);

        if(currentTick % ticksPerCompass == 0 && changePending)
        {
            CompassChange();
            changePending = false;
        }

        if (currentTick % ticksPerCompass == 1)
        {
            changePending = true;
        }
    }

    private void CompassChange()
    {
        foreach (BlinkingPlatform platform in FindObjectsOfType<BlinkingPlatform>())
        {
            platform.Switch();
        }
    }
}
