using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeInterpreter : MonoBehaviour
{
    private static CodeInterpreter instance;
    public static CodeInterpreter Instance { get { return instance; } }
    
    private DialogOption[] messages;
    private TextMeshProUGUI fullDialogText;
    [SerializeField] TextMeshProUGUI title;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            messages = GetComponentsInChildren<DialogOption>();
        }
        else
            DestroyImmediate(this);
    }

    public void SetTitle(Character character)
    {
        if(character == Character.Bob_The_Planet)
            title.text = "What will the planet say?";
        else
            title.text = "What will the boy say?";

    }

    public void SetOptions(Message[] newOptions)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            messages[i].SetMessage(newOptions[i]);
        }
    }

    public void Select(List<Symbol> symbols)
    {
        foreach (DialogOption dialog in messages)
        {
            if (dialog.Message.FirstLetter.Compare(symbols))
                dialog.SetBackground(Color.green);
            else
                dialog.SetBackground(Color.white);
        }

    }
}
