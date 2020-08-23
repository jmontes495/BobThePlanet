using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTextNode : StoryNode
{
    [SerializeField] private Letter firstLetter;
    public Letter FirstLetter { get { return firstLetter; } }
    [SerializeField] private string messageText;
    public virtual string MessageText { get { return messageText; } }
    [SerializeField] private string narratorSubText;
    public virtual string NarratorSubText { get { return narratorSubText; } }

    public void InitForDialog(string message, Character character)
    {
        this.character = character;
        messageText = message;
    }
}
