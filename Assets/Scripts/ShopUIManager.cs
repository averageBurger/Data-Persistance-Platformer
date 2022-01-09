using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Update()
    {
        coinText.text = "Coins: " + MainManager.coins;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

   public void Blue()
   {
        PickColour(9, Color.blue);
   }

    public void Red()
    {
        PickColour(14, Color.red);
    }

    public void Yellow()
    {
        PickColour(19, Color.yellow);
    }
    public void Green()
    {
        PickColour(24, Color.green);
    }

    public void Purple()
    {
        PickColour(29, Color.magenta);
    }

    public void PickColour(int price, Color colour)
    {
        if (MainManager.coins > price && !MainManager.colourArray.Contains(colour))
        {
            MainManager.colourArray.Add(colour);
            MainManager.coins -= (price + 1);
        }

        if (MainManager.colourArray.Contains(colour))
        {
            MainManager.currentColour = colour;
        }
    }

    public void gainCoins()
    {
        MainManager.coins++;
    }
}
