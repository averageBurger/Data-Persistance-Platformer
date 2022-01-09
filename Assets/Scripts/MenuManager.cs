using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Awake()
    {
        if (!MainManager.hasLoaded)
        {
            Load();
            MainManager.hasLoaded = true;
        }
    }

    private void Update()
    {
        coinsText.text = "Coins: " + MainManager.coins;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void EnterShop()
    {
        SceneManager.LoadScene(2);
    }

    [System.Serializable]
    class SaveData
    {
        public int coinsS;
        public List<Color> colourArrayS;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.coinsS = MainManager.coins;
        data.colourArrayS = MainManager.colourArray;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MainManager.coins = data.coinsS;
            MainManager.colourArray = data.colourArrayS;
        }
    }
}
