using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

abstract class StoryLevels : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Text timeDisplay;
    protected float time;

    // Start is called before the first frame update
    protected void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time + 1;
        timeDisplay.text = time.ToString();
    }

    public abstract void EnterArea();

    public abstract void saveTime();

    public abstract void saveLevel();

}
