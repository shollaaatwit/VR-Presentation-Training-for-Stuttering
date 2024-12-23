using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class Numpad : MonoBehaviour
{
    public TMP_Text text;

    // Adds a string to the text box
    public void AddToText(string toAdd)
    {
        text.text += toAdd;
    }

    // Deletes a letter from the text box
    public void Backspace()
    {
        text.text = text.text.Substring(0, text.text.Length - 1);
    }

    // Clears the text box of all characters
    public void Clear()
    {
        text.text = string.Empty;
    }

}
