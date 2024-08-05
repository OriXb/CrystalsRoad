using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float bestTime;
    public float bestTime2;
    public float bestTime3;
    public int bestLevel;
    public int currentStroyLevel;
    public int coins;
    public bool[] skins;
    public int currentGunSkin;
    public int currentPickaxeSkin;

    public PlayerData(float bestTime)
    {
        this.bestTime = bestTime;
    }
    public PlayerData(float bestTime2, float i)
    {
        this.bestTime2 = bestTime2;
    }
    public PlayerData(float bestTime3, float i, float x)
    {
        this.bestTime3 = bestTime3;
    }
    public PlayerData(int bestLevel)
    {
        this.bestLevel = bestLevel;
    }
    public PlayerData(int currentStroyLevel, int i)
    {
        this.currentStroyLevel = currentStroyLevel;
    }
    public PlayerData(int coins, int i, int x)
    {
        this.coins = coins;
    }
    public PlayerData(bool[] skins)
    {
        this.skins = skins;
    }
    public PlayerData(int currentGunSkin, bool x)
    {
        this.currentGunSkin = currentGunSkin;
    }
    public PlayerData(int currentPickaxeSkin, bool x, bool y)
    {
        this.currentPickaxeSkin = currentPickaxeSkin;
    }
}