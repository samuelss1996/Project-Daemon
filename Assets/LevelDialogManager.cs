using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDialogManager : MonoBehaviour
{
    // Editor
    public DialogUI dialogUI;
    public Conversation[] startDialogs;
    public Conversation[] endDialogs;

    // State
    private bool startDialog = true;
    private bool shownStart;
    private bool shownEnd;

    public void ShowStartDialog()
    {
        if(!shownStart)
        {
            dialogUI.SetConversation(startDialogs[SceneManager.GetActiveScene().buildIndex]);
            dialogUI.AdvanceConversation();

            shownStart = true;
        }
    }

    public void ShownEndDialog()
    {
        if(!shownEnd)
        {
            dialogUI.SetConversation(endDialogs[SceneManager.GetActiveScene().buildIndex]);
            dialogUI.AdvanceConversation();

            shownEnd = true;
        }
    }

    public void DialogFinished()
    {
        if(startDialog)
        {
            FindObjectOfType<MusicFader>().FadeIn();
            startDialog = false;
        }
        else
        {
            FindObjectOfType<LevelTransitioner>().NextLevel();
        }
    }
}
