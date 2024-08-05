using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel(int bestLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerLevel.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bestLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadLevel()
    {
        string path = Application.persistentDataPath + "/playerLevel.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter =new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveTime(float bestTime)
    {

            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/playerTime.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(bestTime);

            formatter.Serialize(stream, data);
            stream.Close();
    }

    public static PlayerData LoadTime()
    {
        string path = Application.persistentDataPath + "/playerTime.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveTime2(float bestTime2)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerTime2.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bestTime2, 1.1f);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerData LoadTime2()
    {
        string path = Application.persistentDataPath + "/playerTime2.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveTime3(float bestTime3)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerTime3.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bestTime3, 1.1f,1.1f);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadTime3()
    {
        string path = Application.persistentDataPath + "/playerTime3.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveStoryLevel(int StroyLevel)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerStoryLevel.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(StroyLevel,0);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadStoryLevel()
    {
        string path = Application.persistentDataPath + "/playerStoryLevel.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveCoins(int coins)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerCoins.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(coins, 0, 0);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadCoins()
    {
        string path = Application.persistentDataPath + "/playerCoins.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveSkins(bool[] skins)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerSkins.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(skins);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadSkins()
    {
        string path = Application.persistentDataPath + "/playerSkins.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveCurrentGunSkin(int CurrentGunSkin)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerCurrentGunSkin.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(CurrentGunSkin,true);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadCurrentGunSkin()
    {
        string path = Application.persistentDataPath + "/playerCurrentGunSkin.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }

    public static void SaveCurrentPickaxeSkin(int CurrentPickaxeSkin)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerCurrentPickaxeSkin.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(CurrentPickaxeSkin, true,true);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadCurrentPickaxeSkin()
    {
        string path = Application.persistentDataPath + "/playerCurrentPickaxeSkin.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file dont found in " + path);
            return null;
        }
    }
}
