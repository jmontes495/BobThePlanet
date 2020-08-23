using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Credits;
    [SerializeField] private Image Fade;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !Credits.activeInHierarchy)
        {
            Main.SetActive(false);
            Credits.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) && !Main.activeInHierarchy)
        {
            Main.SetActive(true);
            Credits.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Main.activeInHierarchy)
        {
            StartCoroutine(FadeScene());
        }
    }

    private IEnumerator FadeScene()
    {
        for (float i = 0; i < 1; i += 0.05f)
        {
            Fade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(1);
    }
}
