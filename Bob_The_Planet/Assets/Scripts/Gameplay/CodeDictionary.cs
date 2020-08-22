using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dictionary")]
public class CodeDictionary : ScriptableObject
{
    [SerializeField] private List<Letter> letters;

    public Letter FindLetter(List<Symbol> characters)
    {
        foreach (Letter letter in letters)
        {
            if (letter.Compare(characters))
                return letter;
        }
        return null;
    }
}
