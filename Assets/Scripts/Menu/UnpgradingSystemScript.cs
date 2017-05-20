using UnityEngine;
using System.Collections;

public class UnpgradingSystemScript : MonoBehaviour
{
    #region variables
    public static float playerSpeed;
    public static float playerPower;
    public static float playerBulletsCount;
    public static float coins;
    #endregion

    // Getting and sets the speed and power values
    void Start()
    {
        // Restart PlayerPrefs
        ZeroVariables(false);

        //set main variables
        playerSpeed = GetValueByName("speed");
        playerPower = GetValueByName("power");
        playerBulletsCount = GetValueByName("bullets");
        coins = GetValueByName("coins") + PlayerScript.playerScore;
        PlayerScript.playerScore = 0;
        PlayerPrefs.SetFloat("coins", coins);
    }

    // Setting text by valus to the 3D texts
    void Update()
    {
        if (this.name == "SpeedText")
        {
            this.GetComponent<TextMesh>().text = "speed: " + playerSpeed;
        }
        else if (this.name == "PowerText")
        {
            this.GetComponent<TextMesh>().text = "power: " + playerPower;
        }
        else if (this.name == "BulletsNumberText")
        {
            this.GetComponent<TextMesh>().text = "bullets: " + playerBulletsCount;
        }
        else if (this.name == "CoinsText")
        {
            this.GetComponent<TextMesh>().text = "Souls: " + coins;
        }
    }

    // If speed -> upgrade speed, if power -> upgrade power,, if play button load the game
    void OnMouseDown()
    {
        if (this.name == "speedButton")
        {
            if (GetValueByName("speed") > 85)
            {
                PlayerPrefs.SetFloat("speed", 85);
            }
            else
            {
                if (BuyWithCoins("speed"))
                {
                    PlayerPrefs.SetFloat("speed", (int)(GetValueByName("speed") * 1.5f));
                    if (GetValueByName("speed") > 85)
                    {
                        PlayerPrefs.SetFloat("speed", 85);
                    }
                }
            }
            playerSpeed = GetValueByName("speed");
        }
        else if (this.name == "powerButton")
        {
            if (GetValueByName("power") >= 200)
            {
                PlayerPrefs.SetFloat("power", 200);
            }
            else
            {
                if (BuyWithCoins("power"))
                {
                    PlayerPrefs.SetFloat("power", (int)(GetValueByName("power") * 1.2f));
                    if (GetValueByName("power") > 200)
                    {
                        PlayerPrefs.SetFloat("power", 200);
                    }
                }
            }
            playerPower = GetValueByName("power");
        }
        else if (this.name == "bulletsNumberButton")
        {
            if (BuyWithCoins("bullets"))
            {
                PlayerPrefs.SetFloat("bullets", (int)(GetValueByName("bullets") + 10));
                playerBulletsCount = GetValueByName("bullets");
            }
        }
        else if (this.name == "Zero")
        {
            ZeroVariables(true);
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
            return true;
        }
        return false;
    }

    // Restart PlayerPrefs
    void ZeroVariables(bool todo)
    {
        if (todo == true)
        {
            PlayerPrefs.SetFloat("speed", 0);
            PlayerPrefs.SetFloat("power", 0);
            PlayerPrefs.SetFloat("bullets", 0);
            PlayerPrefs.SetFloat("coins", 0);
        }
    }
}
