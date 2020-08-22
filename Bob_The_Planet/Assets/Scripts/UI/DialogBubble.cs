using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;

    public void SetText(string newText)
    {
        dialogText.text = newText;
    }
}
