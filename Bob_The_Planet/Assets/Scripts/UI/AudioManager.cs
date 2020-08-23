using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] private AudioSource ding;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource space;
    private bool musicOn;

    private void Awake()
    {
        {
            if (instance == null)
            {
                instance = this;
                musicOn = true;
                DontDestroyOnLoad(this);
            }
            else
                DestroyImmediate(this);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && musicOn)
        {
            musicOn = false;
            music.Stop();
            space.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.M) && !musicOn)
        {
            musicOn = true;
            music.Play();
            space.Play();
        }
    }

    public void PlayDing()
    {
        ding.PlayOneShot(ding.clip);
    }
}
