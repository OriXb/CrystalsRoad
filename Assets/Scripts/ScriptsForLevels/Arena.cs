using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


public class Arena : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;

    public int level = 0;
    public int timeToRepeat;
    private int stage = 1;
    public Text levelText;
    public GameObject block;

    public int CoinsCountToSpawn = 3;
    public List<GameObject> coins;

    public List<GameObject> enemyPlaceToSpawn;
    public int EnemysCountToSpawn = 2;

    public List<GameObject> normalEnemys;
    public List<GameObject> medEnemys;
    public List<GameObject> hardEnemys;

    public List<GameObject> crystalsPlaceToSpawn;
    public int CrystalsCountToSpawn = 1;

    public List<GameObject> crystals;

    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void ActiveBlock()
    {
        block.SetActive(true);
    }

    public void Summoning()
    {
        level++;
        levelText.text = "Level: " + level;

        if (level == 6)
        { stage = 2; }
        if (level == 9)
        { stage = 3; }

        if (level % 3 == 0) { timeToRepeat = timeToRepeat - (timeToRepeat / 4); levelText.color = UnityEngine.Random.ColorHSV();
            if (stage == 2) { EnemysCountToSpawn = Convert.ToInt32(EnemysCountToSpawn * 1.25); } }

        if (level % 2 == 0)
        {
            if (stage == 1) { EnemysCountToSpawn = Convert.ToInt32(EnemysCountToSpawn * 1.5); }
            CrystalsCountToSpawn = CrystalsCountToSpawn + 1;
            CoinsCountToSpawn = Convert.ToInt32(CoinsCountToSpawn * 2);
        }
        if(level % 4 == 0)
        {
            if (stage == 3) { EnemysCountToSpawn = Convert.ToInt32(EnemysCountToSpawn * 1.5); }
        }        

        for (int i = 0; i < EnemysCountToSpawn; i++)
        {
            int place = rand.Next(0, enemyPlaceToSpawn.Count);
            if (stage == 1)
            {
                int enemy = rand.Next(0, normalEnemys.Count);
                GameObject go = Instantiate(normalEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                go.name = "NormalEnemy";
            }
            if (stage == 2)
            {
                int randEnemyKind = rand.Next(0, 2);
                if (randEnemyKind == 0)
                {
                    int enemy = rand.Next(0, normalEnemys.Count);
                    GameObject go = Instantiate(normalEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                    go.name = "NormalEnemy";
                }
                if (randEnemyKind == 1)
                {
                    int enemy = rand.Next(0, medEnemys.Count);
                    GameObject go = Instantiate(medEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                    go.name = "MedEnemy";
                }
            }
            if (stage == 3)
            {
                int randEnemyKind = rand.Next(0, 3);
                if (randEnemyKind == 0)
                {
                    int enemy = rand.Next(0, normalEnemys.Count);
                    GameObject go = Instantiate(normalEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                    go.name = "NormalEnemy";
                }
                if (randEnemyKind == 1)
                {
                    int enemy = rand.Next(0, medEnemys.Count);
                    GameObject go = Instantiate(medEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                    go.name = "MedEnemy";
                }
                if (randEnemyKind == 2)
                {
                    int enemy = rand.Next(0, hardEnemys.Count);
                    GameObject go = Instantiate(hardEnemys[enemy], enemyPlaceToSpawn[place].transform.position, enemyPlaceToSpawn[place].transform.rotation);
                    go.name = "HardEnemy";
                }
            }
        }

        for (int i = 0; i < CrystalsCountToSpawn; i++)
        {
            int place = rand.Next(0, crystalsPlaceToSpawn.Count);
            int index = rand.Next(1,11);
            int n = 0;
            if(index <= 3) { n = 1; }
            else if (index <= 5) { n = 2; }
            else { n = 0; }

            GameObject go = Instantiate(crystals[n], crystalsPlaceToSpawn[place].transform.position, crystalsPlaceToSpawn[place].transform.rotation);
            go.name = "Crystal";
        }

        for (int i = 0; i < CoinsCountToSpawn; i++)
        {
            int index = rand.Next(0, 1);
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(778, 319), 60f, UnityEngine.Random.Range(926, 1389));

            GameObject go = Instantiate(coins[index], spawnPosition, Quaternion.identity);
            go.name = "Coin";
            DestroyHimself des = go.AddComponent<DestroyHimself>();
            des.timeToDestroy = 40f;
        }

        Invoke("Summoning", timeToRepeat);

    }

    public void saveLevel()
    {
        PlayerData data = SaveSystem.LoadLevel();
        if (data != null)
        {
            if (level > data.bestLevel)
            { SaveSystem.SaveLevel(level); }
        }
        else { SaveSystem.SaveLevel(level); }

    }
}
