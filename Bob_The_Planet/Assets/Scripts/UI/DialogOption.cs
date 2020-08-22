using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private Image background;
    private Message currentMessage;
    public Message Message { get { return currentMessage; } }

    public void SetMessage(Message message)
    { 
        background.color = Color.white;
        currentMessage = message;
        textField.text = currentMessage.FirstLetter.GetCodeVersion() + "\n" + currentMessage.ShortMessage;
    }

    public void SetBackground(Color color)
    {
        background.color = color;
    }
}
