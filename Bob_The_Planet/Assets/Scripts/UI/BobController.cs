using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hype;
    [SerializeField] private Sprite sad;
    [SerializeField] private Sprite shy;
    void Start()
    {
        StoryNode.BobHype += SetHype;
        StoryNode.BobSad += SetSad;
        StoryNode.BobShy += SetShy;
    }

    private void SetHype()
    {
        spriteRenderer.sprite = hype;
    }

    private void SetSad()
    {
        spriteRenderer.sprite = sad;
    }

    private void SetShy()
    {
        spriteRenderer.sprite = shy;
    }

    private void OnDestroy()
    {
        StoryNode.BobHype -= SetHype;
        StoryNode.BobSad -= SetSad;
        StoryNode.BobShy -= SetShy;
    }
}
