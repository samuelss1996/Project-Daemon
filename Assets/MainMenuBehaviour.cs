using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    // Editor
    public Text start;
    public char caretChar;

    // State
    private bool showingCaret;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CaretBlinkCR());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !started)
        {
            FindObjectOfType<LevelTransitioner>().NextLevel();
            started = true;
        }
    }

    private IEnumerator CaretBlinkCR()
    {
        while (true)
        {
            if (showingCaret)
            {
                RemoveLastChar();
                showingCaret = false;
            }
            else
            {
                AppendChar(caretChar);
                showingCaret = true;
            }
            

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void RemoveLastChar()
    {
        start.text = start.text.Substring(0, start.text.Length - 1);
    }

    private void AppendChar(char c)
    {
        start.text = string.Concat(start.text, c);
    }
}
