using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatformManager : MonoBehaviour
{
    public float tickTime;
    public int ticksPerCompass;

    // State
    private int currentTick;

    private void Start()
    {
        StartCoroutine(TickCR());
    }

    private IEnumerator TickCR()
    {
        while(true)
        {
            currentTick++;

            if(currentTick == ticksPerCompass)
            {
                currentTick = 0;

                foreach(BlinkingPlatform platform in FindObjectsOfType<BlinkingPlatform>())
                {
                    platform.Switch();
                }
            }

            yield return new WaitForSeconds(tickTime);
        }
    }
}
