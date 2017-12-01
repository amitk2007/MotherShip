using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    #region Variables
    public float speed;
    public float bulletSpeed;
    public GameObject bullet;
    GameObject holder;
    bool canShot = false;

    public static float playerScore;
    public static float playerCoins;
    public GameObject textObject;
    public static GameObject ScoreText;
    public GameObject BullestsText;
    public GameObject CoinsText;
    public static float inGameBullets;
    #endregion

    // Use this for initialization
    void Start()
    {
        playerScore = 0;
        //speed = UpgradingSystemScript.playerSpeed;
        ScoreText = textObject;
        inGameBullets = UpgradingSystemScript.playerBulletsCount;
    }

    // Update is called once per frame
    void Update()
    {
        BullestsText.GetComponent<TextMesh>().text = inGameBullets.ToString();
        ScoreText.GetComponent<TextMesh>().text = "Kills: " + playerScore.ToString();
        CoinsText.GetComponent<TextMesh>().text = UpgradingSystemScript.coins.ToString();

        PlayerMovment();

        PlayerShot();
    }

    void PlayerMovment()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }

    void PlayerShot()
    {
        if (Input.touches.Length > 0)
        {
            if (canShot && inGameBullets > 0)
            {
                holder = Instantiate(bullet);
                holder.transform.position = this.transform.position;
                holder.gameObject.GetComponent<Rigidbody>().AddForce(0, bulletSpeed, 0);
                canShot = false;
                if (Input.touches[0].position.x >= Screen.width / 2)
                {
                    holder.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
                else if (Input.touches[0].position.x < Screen.width / 2)
                {
                    holder.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                inGameBullets--;
            }
            else if (canShot && inGameBullets == 0)
            {
                inGameBullets--;
            }
        }
        if (Input.touches.Length == 0)
        {
            canShot = true;
        }
    }
}
