using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;



public class Main : MonoBehaviour
{
    public Camera camMenu;
    public Camera camGame;
    public Camera camControllers;
    public Camera camShop;
    public Canvas shopCan;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    public GameObject player;
    public GameObject controllers;
    public GameObject mainCanves;

    public Button controls;
    public Button scoreboard;
    public Button start;

    public Image choose;
    public Button arena;
    public Button story;

    public Image TScoreboard;
    public Image LScoreboard;
    public Text timeScoreboard;
    public Text time2Scoreboard;
    public Text time3Scoreboard;
    public Text levelScoreboard;
    public Text storyLevelScoreboard;
    public Button reset;

    public Image selectLevel;
    public Button l1;
    public Button l2;
    public Button l3;

    public Text skip;
    public GameObject options;
    public InputField codeConsole;
    public GameObject codeEnter;
    public UnityEvent opneShop;

    public UnityEvent LoadLevelOne;
    public UnityEvent LoadLevelTwo;
    public UnityEvent LoadLevelThree;
    public UnityEvent LoadArena;

    // Start is called before the first frame update
    void Start()
    {
        choose.gameObject.SetActive(false);
        arena.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        saveLevel0();

    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Awake()
    {
        Cursor.visible = true;
        mainCanves.SetActive(true);
        controllers.SetActive(false);
        player.SetActive(false);
        camMenu.enabled = true;
        camGame.enabled = false;
        camControllers.enabled = false;
        camShop.enabled = false;
        shopCan.gameObject.SetActive(false);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && camGame.enabled)
        {
            skip.text = "";
            LoadLevelOne.Invoke();
        }
    }
    public void saveLevel0()
    {
        PlayerData data = SaveSystem.LoadStoryLevel();
        if (data == null)
        {
             SaveSystem.SaveStoryLevel(0); 
        }


    }
    public void MainToLevelOne()
    {
        LoadLevelOne.Invoke();
    }

    public void onButtonShop()
    {

        shopCan.gameObject.SetActive(true);
        camMenu.enabled = false;
        camShop.enabled = true;
        opneShop.Invoke();
    }

    public void ResetStats()
    {
        SaveSystem.SaveStoryLevel(0);
        SaveSystem.SaveLevel(0);
        SaveSystem.SaveTime(int.MaxValue);
        SaveSystem.SaveTime2(int.MaxValue);
        SaveSystem.SaveTime3(int.MaxValue);

        SaveSystem.SaveLevel(0);
        storyLevelScoreboard.text = "Current Level: " + 0;
        timeScoreboard.text = "-";
        time2Scoreboard.text = "-";
        time3Scoreboard.text = "-";
        levelScoreboard.text = 0.ToString(); ;
    }

    public void Options()
    {
        codeConsole.gameObject.SetActive(true);
        codeEnter.SetActive(true);
        Destroy(options); 
    }

    public void EnterCode()
    {
        string str = codeConsole.text;
        if (str == "/coins123c")
        {
            PlayerData data = SaveSystem.LoadCoins();
            SaveSystem.SaveCoins(data.coins + 100);
        }
        if (str == "/clearEverythingg")
        {
            SaveSystem.SaveStoryLevel(0);
            SaveSystem.SaveLevel(0);
            SaveSystem.SaveTime(int.MaxValue);
            SaveSystem.SaveTime2(int.MaxValue);
            SaveSystem.SaveTime3(int.MaxValue);
            SaveSystem.SaveSkins(new bool[8]);
            SaveSystem.SaveCoins(0);
        }
        if (str == "/YesGiveMeAll321")
        {
            SaveSystem.SaveStoryLevel(3);
            SaveSystem.SaveLevel(100);
            SaveSystem.SaveTime(int.MaxValue);
            SaveSystem.SaveTime2(int.MaxValue);
            SaveSystem.SaveTime3(int.MaxValue);
            SaveSystem.SaveSkins(new bool[8]);
            SaveSystem.SaveCoins(100000);
        }
        if (str == "/MegaPigIsCool")
        {
            bool[] skins = new bool[8];
            PlayerData data = SaveSystem.LoadSkins();

            if (data == null)
            {
                SaveSystem.SaveSkins(skins);
            }
            skins = data.skins;
            skins[5] = true;
            SaveSystem.SaveSkins(skins);
        }
    }

    public void onButtonScoreboardClick()
    {
        Invoke("CleanScoreboardClick", 5);
        start.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        scoreboard.gameObject.SetActive(false);

        reset.gameObject.SetActive(true);
        TScoreboard.gameObject.SetActive(true);
        LScoreboard.gameObject.SetActive(true);
        timeScoreboard.gameObject.SetActive(true);
        time2Scoreboard.gameObject.SetActive(true);
        time3Scoreboard.gameObject.SetActive(true);
        levelScoreboard.gameObject.SetActive(true);
        storyLevelScoreboard.gameObject.SetActive(true);
        PlayerData dataTime = SaveSystem.LoadTime();
        PlayerData dataTime2 = SaveSystem.LoadTime2();
        PlayerData dataTime3 = SaveSystem.LoadTime3();
        PlayerData dataLevel = SaveSystem.LoadLevel();
        PlayerData dataStoryLevel = SaveSystem.LoadStoryLevel();
        storyLevelScoreboard.text = "Current Level: " + dataStoryLevel.currentStroyLevel.ToString();
        levelScoreboard.text = dataLevel.bestLevel.ToString();
        if(dataTime.bestTime == int.MaxValue)
        {
            timeScoreboard.text = "-";
        }
        else
        { timeScoreboard.text = dataTime.bestTime.ToString();}
        if (dataTime2.bestTime2 == int.MaxValue)
        {
            time2Scoreboard.text = "-";
        }
        else
        { time2Scoreboard.text = dataTime2.bestTime2.ToString();}
        if (dataTime3.bestTime3 == int.MaxValue)
        {
            time3Scoreboard.text = "-";
        }
        else
        { time3Scoreboard.text = dataTime3.bestTime3.ToString();}

    }
     void CleanScoreboardClick()
    {
        start.gameObject.SetActive(true);
        controls.gameObject.SetActive(true);
        scoreboard.gameObject.SetActive(true);

        reset.gameObject.SetActive(false);
        TScoreboard.gameObject.SetActive(false);
        LScoreboard.gameObject.SetActive(false);
        timeScoreboard.gameObject.SetActive(false);
        time2Scoreboard.gameObject.SetActive(false);
        time3Scoreboard.gameObject.SetActive(false);
        levelScoreboard.gameObject.SetActive(false);
        storyLevelScoreboard.gameObject.SetActive(false);
        timeScoreboard.text = "";
        time2Scoreboard.text = "";
        time3Scoreboard.text = "";
        levelScoreboard.text = "";
    }


    public void onButtonStartClick()
    {
        arena.gameObject.SetActive(true);
        story.gameObject.SetActive(true);

        choose.gameObject.SetActive(true);
        controls.gameObject.SetActive(false);
        scoreboard.gameObject.SetActive(false);
    }

    public void onButtonArenaClick()
    {
        LoadArena.Invoke();

    }

    public void onButtonStoryClick()
    {
        PlayerData data = SaveSystem.LoadStoryLevel();
        int level = data.currentStroyLevel;
        if (level == 0 || level == null)
        {
            audioSource.clip = audioClip2;
            audioSource.Play();
            camMenu.enabled = false;
            camGame.enabled = true;
            player.SetActive(true);
            skip.text = "Click enter to skip tutorial!";
        }
        else
        {
            start.gameObject.SetActive(false);
            selectLevel.gameObject.SetActive(true);
            arena.gameObject.SetActive(false);
            story.gameObject.SetActive(false);
            choose.gameObject.SetActive(false);

            l1.gameObject.SetActive(true);
            l2.gameObject.SetActive(true);
            l3.gameObject.SetActive(true);

            if(level == 1)
            {
                l1.GetComponent<Image>().color = Color.green;
                l2.GetComponent<Image>().color = Color.green;
                l3.GetComponent<Image>().color = Color.red;
            }
            else
            { 
                l1.GetComponent<Image>().color = Color.green;
                l2.GetComponent<Image>().color = Color.green;
                l3.GetComponent<Image>().color = Color.green;
            }
        }

    }

    public void onButtonLvl1()
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
        camMenu.enabled = false;
        camGame.enabled = true;
        player.SetActive(true);
        skip.text = "Click enter to skip tutorial!";
    }
    public void onButtonLvl2()
    {
        if (l2.GetComponent<Image>().color == Color.green)
        {
            LoadLevelTwo.Invoke();
        }
    }
    public void onButtonLvl3()
    {
        if (l3.GetComponent<Image>().color == Color.green)
        {
            LoadLevelThree.Invoke();
        }
    }

    public void onControllersButtonClick()
    {
        mainCanves.SetActive(false);
        controllers.SetActive(true);
        camMenu.enabled = false;
        camControllers.enabled = true;
        
    }
    public void onBackToMenuButtonClick()
    {
        mainCanves.SetActive(true);
        controllers.SetActive(false);
        camControllers.enabled = false;
        camMenu.enabled = true;
    }
    public void onBackToMenuShopButtonClick()
    {
        shopCan.gameObject.SetActive(false);
        camMenu.enabled = true;
        camShop.enabled = false;
    }
}
