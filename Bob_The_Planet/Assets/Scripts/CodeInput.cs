using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInput : MonoBehaviour
{
    [SerializeField] private float DelayBetweenLetters;
    [SerializeField] private float DelayBetweenSymbols;
    [SerializeField] private CodeDictionary codeDictionary;

    private float currentDelay;
    private List<Symbol> currentSymbols;
    private bool isTyping;
    private bool isHolding;

    private void Start()
    {
        currentSymbols = new List<Symbol>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDelay += Time.deltaTime;

        if (isTyping && !Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Space) && currentDelay >= DelayBetweenLetters)
        {
            isTyping = false;
            currentDelay = 0;
            Letter letter = codeDictionary.FindLetter(currentSymbols);
            Debug.LogError(letter != null ? letter.Character : "No match");
            currentSymbols.Clear();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isHolding)
        {
            isHolding = true;
            isTyping = true;
            currentDelay = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isHolding)
        {
            isHolding = false;
            if (currentDelay >= DelayBetweenSymbols)
                currentSymbols.Add(Symbol.Line);
            else
                currentSymbols.Add(Symbol.Point);

            currentDelay = 0;
        }
    }
}
