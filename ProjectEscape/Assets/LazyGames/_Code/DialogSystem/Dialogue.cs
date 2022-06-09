using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string character;
    public Sprite Sprite;

    [TextArea(3,10)]
    public string[] sentences;
    
}
