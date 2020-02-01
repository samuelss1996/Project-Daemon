using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Fader>().FadeIn();
        FindObjectOfType<MusicFader>().FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        FindObjectOfType<Fader>().FadeOut();
        FindObjectOfType<MusicFader>().FadeOut();
    }
}
