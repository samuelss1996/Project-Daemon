﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Fader>().FadeIn();
        FindObjectOfType<LevelDialogManager>()?.ShowStartDialog();
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        FindObjectOfType<RestartKeeper>()?.Clear();

        if(currentIndex == 5)
        {
            FindObjectOfType<PlayerDeath>().DieVisually();
            StartCoroutine(LoadLevelCR(0));
            Destroy(GameObject.FindGameObjectWithTag("RestartKeeper"));
        }
        else
        {
            StartCoroutine(LoadLevelCR(currentIndex + 1));
        }
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevelCR(SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator LoadLevelCR(int buildIndex)
    {
        FindObjectOfType<Fader>().FadeOut();
        FindObjectOfType<MusicFader>()?.FadeOut();

        yield return new WaitForSeconds(FindObjectOfType<Fader>().fadeTime);

        SceneManager.LoadScene(buildIndex);
    }
}
