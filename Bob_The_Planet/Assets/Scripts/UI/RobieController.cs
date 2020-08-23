using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobieController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite smiley;
    [SerializeField] private Sprite happy;

    void Start()
    {
        StoryNode.KidSmile += SetSmiley;
        StoryNode.KidHappy += SetHappy;
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

    }

    private void SetSmiley()
    {
        spriteRenderer.sprite = smiley;
    }

    private void SetHappy()
    {
        spriteRenderer.sprite = happy;
    }

    private void OnDestroy()
    {
        StoryNode.KidSmile += SetSmiley;
        StoryNode.KidHappy += SetHappy;
    }
}
