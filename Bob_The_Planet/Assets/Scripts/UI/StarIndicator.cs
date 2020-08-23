using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarIndicator : MonoBehaviour
{
    [SerializeField] private Image star;
    [SerializeField] private float fadeSpeed;

    private bool starIsOn;
    private float currentAlpha;
    private WaitForSeconds Delay;

    private void Start()
    {
        Delay = new WaitForSeconds(fadeSpeed);   
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            AudioManager.Instance.PlayDing();
            if (!starIsOn)
            {
                starIsOn = true;
                FadeIn();
            }
        }
        else
        {
            if (starIsOn)
            {
                starIsOn = false;
                FadeOut();
            }
        }
    }

    private void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeStarIn());
    }

    private void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeStarOut());
    }

    private IEnumerator FadeStarIn()
    {
        while (currentAlpha < 1.0f)
        {
            currentAlpha += 0.1f;
            star.color = new Color(1, 1, 1, currentAlpha);
            yield return Delay;
        }
    }

    private IEnumerator FadeStarOut()
    {
        while (currentAlpha >0)
        {
            currentAlpha -= 0.1f;
            star.color = new Color(1, 1, 1, currentAlpha);
            yield return Delay;
        }
    }
}
