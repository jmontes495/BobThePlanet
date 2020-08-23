using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI morseText;

    public void SetText(string morse, string newText)
    {
        dialogText.text = newText;
        morseText.text = morse;
    }
}
