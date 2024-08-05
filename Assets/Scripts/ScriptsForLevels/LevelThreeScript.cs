﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 class LevelThreeScript : StoryLevels
{
    void Start()
    {
        base.Start();

    }

    public override void EnterArea()
    {
        saveTime();
        saveLevel();
        SceneManager.LoadScene(3);
    }

    public override void saveTime()
    {
        PlayerData data = SaveSystem.LoadTime3();
        if (data != null)
        {
            if (base.time < data.bestTime3)
            { SaveSystem.SaveTime3(base.time); }
        }
        else { SaveSystem.SaveTime3(base.time); }

    }
    public override void saveLevel()
    {
        PlayerData data = SaveSystem.LoadStoryLevel();
        if (data != null)
        {
            if (data.currentStroyLevel < 3)
            { SaveSystem.SaveStoryLevel(3); }
        }
        else { SaveSystem.SaveStoryLevel(3); }

    }
}
