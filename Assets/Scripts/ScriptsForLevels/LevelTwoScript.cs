using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class LevelTwoScript : StoryLevels
{

    // Start is called before the first frame update
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
        PlayerData data = SaveSystem.LoadTime2();
        if (data != null)
        {
            if (base.time < data.bestTime2)
            { SaveSystem.SaveTime2(base.time); }
        }
        else { SaveSystem.SaveTime2(base.time); }

    }
    public override void saveLevel()
    {
        PlayerData data = SaveSystem.LoadStoryLevel();
        if (data != null)
        {
            if (data.currentStroyLevel < 2)
            { SaveSystem.SaveStoryLevel(2); }
        }
        else { SaveSystem.SaveStoryLevel(2); }

    }
}
