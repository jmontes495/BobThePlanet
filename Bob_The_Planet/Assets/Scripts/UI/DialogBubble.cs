using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI morseText;
    [SerializeField] private TextMeshProUGUI subText;

    public void SetText(string morse, string newText, string addedText = "")
    {
        dialogText.text = newText;
        morseText.text = morse;
        if (subText != null)
            subText.text = addedText;
    }
}
