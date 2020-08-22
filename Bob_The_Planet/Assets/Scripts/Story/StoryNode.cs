using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNode : MonoBehaviour
{
    [SerializeField] protected Character character;
    public Character Character { get { return character; } }
    public virtual bool HasOptions()
    {
        return false;
    }
}
