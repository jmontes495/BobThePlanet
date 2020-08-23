using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private static StoryManager instance;
    public static StoryManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            DestroyImmediate(this);
    }

    [SerializeField] private DialogBubble planetDialog;
    [SerializeField] private DialogBubble kidDialog;
    [SerializeField] private DialogBubble narratorScreen;
    [SerializeField] private CodeInterpreter optionsScreen;
    [SerializeField] private SingleTextNode auxiliarNode;

    private StoryNode[] storyNodes;
    private Character currentCharacter;
    private int nodeIndex;
    private StoryNode currentNode;
    private bool inDelay;
    private bool shouldIgnoreLetter;

    private void Start()
    {
        storyNodes = GetComponentsInChildren<StoryNode>();
        nodeIndex = 0;
        currentNode = storyNodes[nodeIndex];
        currentCharacter = currentNode.Character;
        ShowCurrentMessage();
    }

    private void HideAll()
    {
        planetDialog.gameObject.SetActive(false);
        kidDialog.gameObject.SetActive(false);
        narratorScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
    }

    private void ShowCurrentMessage()
    {
        HideAll();
        currentNode.CallForEmotions();
        if (currentNode.HasOptions())
            ShowOptions();
        else
        {
            switch (currentNode.Character)
            {
                case Character.Bob_The_Planet:
                    ShowBobMessage();
                    break;
                case Character.The_Boy:
                    ShowKidMessage();
                    break;
                case Character.Narrator:
                    ShowNarratorMessage();
                    break;
            }
        }
    }

    private void ShowBobMessage()
    {
        planetDialog.gameObject.SetActive(true);
        SingleTextNode textNode = (SingleTextNode)currentNode;
        planetDialog.SetText(shouldIgnoreLetter ? "" : textNode.FirstLetter.GetCodeVersion(), textNode.MessageText);
        shouldIgnoreLetter = false;
    }

    private void ShowKidMessage()
    {
        SingleTextNode textNode = (SingleTextNode)currentNode;
        if (textNode.MessageText.CompareTo("") != 0)
        {
            kidDialog.gameObject.SetActive(true);
            kidDialog.SetText(shouldIgnoreLetter ? "" : textNode.FirstLetter.GetCodeVersion(), textNode.MessageText);
            shouldIgnoreLetter = false;
        }
    }

    private void ShowNarratorMessage()
    {
        narratorScreen.gameObject.SetActive(true);
        SingleTextNode textNode = (SingleTextNode)currentNode;
        narratorScreen.SetText("", textNode.MessageText);
    }

    private void ShowOptions()
    {
        optionsScreen.gameObject.SetActive(true);
        OptionsNode optionsNode = (OptionsNode)currentNode;
        optionsScreen.SetTitle(currentCharacter);
        optionsScreen.SetOptions(optionsNode.Options);
    }

    public void PlayerSelectedLetter(List<Symbol> symbols)
    {
        if (inDelay)
            return;

        if (currentNode.HasOptions())
        {
            OptionsNode optionsNode = (OptionsNode)currentNode;
            foreach (Message dialog in optionsNode.Options)
            {
                if (dialog.FirstLetter.Compare(symbols))
                {
                    StartCoroutine(SelectionDelay(dialog, symbols));
                }
            }
        }
        else
        {
            SingleTextNode textNode = (SingleTextNode)currentNode;
            if (textNode.FirstLetter.Compare(symbols))
            {
                nodeIndex++;
                currentNode = storyNodes[nodeIndex];
                currentCharacter = currentNode.Character;
                ShowCurrentMessage();
            }
        }

    }

    private IEnumerator SelectionDelay(Message message, List<Symbol> symbols)
    {
        inDelay = true;
        optionsScreen.Select(symbols);
        yield return new WaitForSeconds(1.0f);
        shouldIgnoreLetter = true;
        auxiliarNode.InitForDialog(message.FullMessage, currentCharacter);
        currentNode = auxiliarNode;
        currentCharacter = currentNode.Character;
        ShowCurrentMessage();
        inDelay = false;
    }
}
