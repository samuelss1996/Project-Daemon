using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(menuName = "Dialog/Conversation")]
public class Conversation : ScriptableObject
{
    public Line[] lines;
}
