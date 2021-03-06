﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    public Text dialog;

    public void SetText(string text)
    {
        dialog.text = text;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void RemoveLastChar()
    {
        dialog.text = dialog.text.Substring(0, Mathf.Max(0, dialog.text.Length - 1));
    }

    public void AppendChar(char character)
    {
        dialog.text = string.Concat(dialog.text, character);
    }
}