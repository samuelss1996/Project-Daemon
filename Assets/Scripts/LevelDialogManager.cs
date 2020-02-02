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

            if(FindObjectOfType<RestartKeeper>().dialogShown)
            {
                dialogUI.SetConversationFinished();
            }

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
            FindObjectOfType<MusicFader>().SemiFadeOut();
        }
    }

    public void DialogFinished()
    {
        if(startDialog)
        {
            FindObjectOfType<MusicFader>().FadeIn();
            startDialog = false;
            FindObjectOfType<RestartKeeper>().dialogShown = true;
        }
        else
        {
            FindObjectOfType<LevelTransitioner>().NextLevel();
        }
    }
}
