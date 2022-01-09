using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class MainManager
{
    public static int coins = 9;
    public static List<Color> colourArray;

    static void Awake()
    {
        colourArray.Add(Color.white);
        Load();
    }

    class SaveData
    {
        public int coins;
        public List<Color> colourArray;
    }

    public static void Save()
    {
        var data = new SaveData();
        data.coins = coins;
        data.colourArray = colourArray;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(path);

            coins = data.coins;
            colourArray = data.colourArray;
        }
    }
}
