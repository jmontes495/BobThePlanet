using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Letter")]
public class Letter : ScriptableObject
{
    [SerializeField] private List<Symbol> symbols;
    [SerializeField] private string character;
    public string Character { get { return character; } }

    public bool Compare(List<Symbol> characters)
    {
        if (characters.Count != symbols.Count)
            return false;

        for (int i = 0; i < symbols.Count; i++)
        {
            if (symbols[i] != characters[i])
                return false;
        }
        return true;
    }
}
