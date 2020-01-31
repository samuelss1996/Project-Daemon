using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUI : MonoBehaviour
{
    // Editor parameters
    public Conversation conversation;
    public GameObject speakerPanel;
    public float timeBetweenChars;

    // Other variables
    [HideInInspector]
    public bool isFinsihed = false;

    // References
    private SpeakerUI speakerUI;

    // State
    private int activeLineIndex = 0;
    private bool animatingText = true;

    private void Start()
    {
        speakerUI = speakerPanel.GetComponent<SpeakerUI>();
        SetConversation(conversation);
    }

    private void Update()
    {
        if(Input.GetButtonUp("Jump") && !animatingText && !isFinsihed)
        {
            AdvanceConversation();    
        }
    }

    public void SetConversation(Conversation newConversation)
    {
        conversation = newConversation;
        speakerUI.Hide();

        AdvanceConversation();
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
        speakerUI.Show();
        StartCoroutine(AnimateTextCR(text));
    }

    private IEnumerator AnimateTextCR(string text)
    {
        animatingText = true;

        for(int i = 0; i < text.Length; i++)
        {
            speakerUI.SetText(text.Substring(0, i + 1));
            yield return new WaitForSeconds(timeBetweenChars);
        }

        animatingText = false;
    }
}
