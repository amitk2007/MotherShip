using UnityEngine;
using System.Collections;
using System;


public class UpgradingSystemScript : MonoBehaviour
{
    #region variables
    //variables
    public static float playerSpeed = 0;
    public static float playerPower = 0;
    public static float playerBulletsCount = 0;
    //other
    public static float coins;
    public static float level;
    #endregion

    // Getting and sets the speed and power values
    void Start()
    {
        // Restart PlayerPrefs
        RestartVariables(false);

        //set main varibales
        playerSpeed = GetValueByName("speed");
        playerPower = GetValueByName("power");
        playerBulletsCount = GetValueByName("bullets");

        //set other variables
        level = GetValueByName("level");
        coins = GetValueByName("coins");
        PlayerScript.playerScore = 0;
        PlayerPrefs.SetFloat("coins", coins);
    }

    // Setting text by valus to the 3D texts
    void Update()
    {
        if (this.name == "PowerText")
        {
            this.GetComponent<TextMesh>().text = "" + playerPower;
        }
        else if (this.name == "BulletsNumberText")
        {
            this.GetComponent<TextMesh>().text = "" + playerBulletsCount;
        }
        else if (this.name == "CoinsText")
        {
            this.GetComponent<TextMesh>().text = "" + coins;
        }
    }

    // If speed -> upgrade speed, if power -> upgrade power,, if play button load the game
    void OnMouseDown()
    {
        if (this.name == "powerButton")
        {
            if (BuyWithCoins("power"))
            {
                PlayerPrefs.SetFloat("power", (int)(GetValueByName("power") * 1.2f));
                if (GetValueByName("power") > 200)
                {
                    PlayerPrefs.SetFloat("power", 200);
                }
            }
            playerPower = GetValueByName("power");
        }
        else if (this.name == "bulletsNumberButton")
        {
            if (BuyWithCoins("bullets"))
            {
                PlayerPrefs.SetFloat("bullets", (int)(GetValueByName("bullets") + 10));
            }
            playerBulletsCount = GetValueByName("bullets");
        }
        else if (this.name == "Restart")
        {
            RestartVariables(true);
            Application.LoadLevel("Menu");
        }
        else if (this.name == "PlayButton")
        {
            Application.LoadLevel("MainGame");
        }
    }

    // Gets the corrent value by the name, if zero sets to defult
    float GetValueByName(string name)
    {
        // On first start set speed and power to defult values
        if (PlayerPrefs.GetFloat(name) == 0)
        {
            if (name == "speed")
            {
                PlayerPrefs.SetFloat(name, 10);
            }
            else if (name == "power")
            {
                PlayerPrefs.SetFloat(name, 50);
            }
            else if (name == "bullets")
            {
                PlayerPrefs.SetFloat(name, 10);
            }
        }

        return PlayerPrefs.GetFloat(name);
    }

    bool BuyWithCoins(string buyName)
    {
        if (GetValueByName(buyName) <= coins)
        {
            coins = coins - GetValueByName(buyName);
            PlayerPrefs.SetFloat("coins", coins);
            return true;
        }
        return false;
    }

    // Restart PlayerPrefs
    void RestartVariables(bool todo)
    {
        if (todo == true)
        {
            PlayerPrefs.SetFloat("speed", 10);
            PlayerPrefs.SetFloat("power", 50);
            PlayerPrefs.SetFloat("bullets", 10);
            PlayerPrefs.SetFloat("coins", 1000);
        }
    }

    void SaveStats(string speed, string power, string bullets, float fspeed, float fpower, float fbullets)
    {
        string[] arr = new string[] { speed, power, bullets };
        float[] farr = new float[] { fspeed, fpower, fbullets };
        for (int i = 0; i < arr.Length; i++)
        {
            PlayerPrefs.SetFloat(arr[i], farr[i]);
        }
    }
}
