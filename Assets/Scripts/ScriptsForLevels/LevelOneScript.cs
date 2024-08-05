using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 class LevelOneScript : StoryLevels
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
        PlayerData data = SaveSystem.LoadTime();
        if(data != null)
        {
            if(base.time < data.bestTime)
            { SaveSystem.SaveTime(base.time); }
        }
        else { SaveSystem.SaveTime(base.time); }
        
    }
    public override void saveLevel()
    {
        PlayerData data = SaveSystem.LoadStoryLevel();
        if (data != null)
        {
            if (data.currentStroyLevel < 1)
            { SaveSystem.SaveStoryLevel(1); }
        }
        else { SaveSystem.SaveStoryLevel(1); }

    }
}
