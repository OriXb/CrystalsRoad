using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EndScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public UnityEvent LoadMain;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick()
    {
        LoadMain.Invoke();
    }
}
