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
    public string ShortMessage { get { return shortMessage; } }
    [SerializeField] private string fullMessage;
    public string FullMessage { get { return fullMessage; } }

}
