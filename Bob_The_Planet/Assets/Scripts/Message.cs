using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private Letter firstLetter;
    public Letter FirstLetter { get { return firstLetter; } }
    [SerializeField] private string shortMessage;
    [SerializeField] private string fullMessage;
    public string FullMessage { get { return fullMessage; } }


    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private Image background;

    private void Start()
    {
        textField.text =  firstLetter.GetCodeVersion() + "\n" + shortMessage;
    }

    public void SetBackground(Color color)
    {
        background.color = color;
    }
}
