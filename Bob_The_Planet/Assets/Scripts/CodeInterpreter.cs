using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeInterpreter : MonoBehaviour
{
    private static CodeInterpreter instance;
    public static CodeInterpreter Instance { get { return instance; } }

    [SerializeField] private GameObject messagesContainer;
    [SerializeField] private GameObject fullDialog;

    private Message[] messages;
    private TextMeshProUGUI fullDialogText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            DestroyImmediate(this);
    }

    private void Start()
    {
        messages = GetComponentsInChildren<Message>();
        fullDialogText = fullDialog.GetComponentInChildren<TextMeshProUGUI>();
        fullDialog.SetActive(false);
    }

    public void Select(List<Symbol> symbols)
    {
        fullDialog.SetActive(false);

        foreach (Message message in messages)
        {
            if (message.FirstLetter.Compare(symbols))
            {
                message.SetBackground(Color.yellow);
                fullDialog.SetActive(true);
                fullDialogText.text = message.FullMessage;
            }
            else
                message.SetBackground(Color.white);
        }

    }
}
