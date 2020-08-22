using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsNode : StoryNode
{
    private Message[] options;
    public Message[] Options { get { return options; } }

    private void Start()
    {
        options = GetComponentsInChildren<Message>();    
    }

    public override bool HasOptions()
    {
        return true;
    }
}
