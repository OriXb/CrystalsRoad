using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    public Button g1;
    public Text tg1;

    public Button g2;
    public Text tg2;

    public Button g3;
    public Text tg3;

    public Button g4;
    public Text tg4;

    public Button p1;
    public Text tp1;
    
    public Button p2;
    public Text tp2;
    
    public Button p3;
    public Text tp3;
    
    public Button p4;
    public Text tp4;
    
    public Text coinCount;

    public Text message;

    bool[] skins = new bool[8];

    public void openShop()
    {
        PlayerData data = SaveSystem.LoadSkins();

        if (data == null)
        {
            SaveSystem.SaveSkins(skins);
        }
        skins = data.skins;
        skins[0] = true;
        skins[4] = true;

        PlayerData data2 = SaveSystem.LoadCoins();
        if (data2 == null)
        {
            SaveSystem.SaveCoins(0);
        }
        coinCount.text = data2.coins.ToString();

        if (!skins[0])
        {
            Image buttonImage = g1.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tg1.text = "Owned"; Image buttonImage = g1.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[1])
        {
            Image buttonImage = g2.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else {
            tg2.text = "Owned"; Image buttonImage = g2.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[2])
        {
            Image buttonImage = g3.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tg3.text = "Owned"; Image buttonImage = g3.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[3])
        {
            Image buttonImage = g4.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tg4.text = "Owned"; Image buttonImage = g4.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[4])
        {
            Image buttonImage = p1.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tp1.text = "Owned"; Image buttonImage = p1.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[5])
        {
            Image buttonImage = p2.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tp2.text = "Owned"; Image buttonImage = p2.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[6])
        {
            Image buttonImage = p3.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tp3.text = "Owned"; Image buttonImage = p3.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

        if (!skins[7])
        {
            Image buttonImage = p4.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
        else { tp4.text = "Owned"; Image buttonImage = p4.GetComponent<Image>();
            buttonImage.color = Color.white;
        }

    }

    void ClearMessage()
    {
        message.text = "";
    }

    public void onG1Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tg1.text == "Owned")
        { SaveSystem.SaveCurrentGunSkin(0); }
        else if (int.Parse(tg1.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tg1.text);
            SaveSystem.SaveCoins(n);
            skins[0] = true;
            SaveSystem.SaveSkins(skins);
            tg1.text = "Owned"; Image buttonImage = g1.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onG2Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tg2.text == "Owned")
        { SaveSystem.SaveCurrentGunSkin(1); }
        else if (int.Parse(tg2.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tg2.text);
            SaveSystem.SaveCoins(n);
            skins[1] = true;
            SaveSystem.SaveSkins(skins);
            tg2.text = "Owned"; Image buttonImage = g2.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onG3Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tg3.text == "Owned")
        { SaveSystem.SaveCurrentGunSkin(2); }
        else if (int.Parse(tg3.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tg3.text);
            SaveSystem.SaveCoins(n);
            skins[2] = true;
            SaveSystem.SaveSkins(skins);
            tg3.text = "Owned"; Image buttonImage = g3.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onG4Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tg4.text == "Owned")
        { SaveSystem.SaveCurrentGunSkin(3); }
        else if (int.Parse(tg4.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tg4.text);
            SaveSystem.SaveCoins(n);
            skins[3] = true;
            SaveSystem.SaveSkins(skins);
            tg4.text = "Owned"; Image buttonImage = g4.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onT1Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tp1.text == "Owned")
        { SaveSystem.SaveCurrentPickaxeSkin(0); }
        else if (int.Parse(tp1.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tp1.text);
            SaveSystem.SaveCoins(n);
            skins[4] = true;
            SaveSystem.SaveSkins(skins);
            tp1.text = "Owned"; Image buttonImage = p1.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onT2Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tp2.text == "Owned")
        { SaveSystem.SaveCurrentPickaxeSkin(1); }
        else if (int.Parse(tp2.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tp2.text);
            SaveSystem.SaveCoins(n);
            skins[5] = true;
            SaveSystem.SaveSkins(skins);
            tp2.text = "Owned"; Image buttonImage = p2.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = (data.coins - int.Parse(tg1.text) ).ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onT3Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tp3.text == "Owned")
        { SaveSystem.SaveCurrentPickaxeSkin(2); }
        else if (int.Parse(tp3.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tp3.text);
            SaveSystem.SaveCoins(n);
            skins[6] = true;
            SaveSystem.SaveSkins(skins);
            tp3.text = "Owned"; Image buttonImage = p3.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }
    public void onT4Click()
    {
        PlayerData data = SaveSystem.LoadCoins();
        if (tp4.text == "Owned")
        { SaveSystem.SaveCurrentPickaxeSkin(3); }
        else if (int.Parse(tp4.text) <= data.coins)
        {
            int n = data.coins - int.Parse(tp4.text);
            SaveSystem.SaveCoins(n);
            skins[7] = true;
            SaveSystem.SaveSkins(skins);
            tp4.text = "Owned"; Image buttonImage = p4.GetComponent<Image>();
            buttonImage.color = Color.white;
            coinCount.text = n.ToString();
        }
        else { message.text = "Not enough coins!"; Invoke("ClearMessage", 2); }
    }

}
