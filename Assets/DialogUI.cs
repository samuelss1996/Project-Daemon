using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUI : MonoBehaviour
{
    // Editor parameters
    public Conversation conversation;
    public GameObject speakerPanel;

    // Other variables
    [HideInInspector]
    public bool isFinsihed = false;

    // References
    private SpeakerUI speakerUI;

    // State
    private int activeLineIndex = 0;

    private void Start()
    {
        speakerUI = speakerPanel.GetComponent<SpeakerUI>();
        SetConversation(conversation);
    }

    private void Update()
    {
        if(Input.GetButtonUp("Jump"))
        {
            AdvanceConversation();    
        }
    }

    public void SetConversation(Conversation newConversation)
    {
        conversation = newConversation;
        speakerUI.Hide();
    }

    public void AdvanceConversation()
    {
        if(activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex++;
        }
        else
        {
            speakerUI.Hide();
            activeLineIndex = 0;
            isFinsihed = true;
        }
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        SetDialog(line.text);
    }

    void SetDialog(string text)
    {
        speakerUI.SetText(text);
        speakerUI.Show();
    }
}
