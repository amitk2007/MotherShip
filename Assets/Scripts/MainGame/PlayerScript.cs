using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    #region Variables
    public float speed;
    public float bulletSpeed;
    public GameObject bullet;
    GameObject holder;
    bool canShot = true;

    public static float playerScore;
    public GameObject textObject;
    public static GameObject ScoreText;
    public GameObject BullestsText;
    float inGameBullets;
    public static float InGameBullets;
    #endregion

    // Use this for initialization
    void Start()
    {
        playerScore = 0;
        speed = UnpgradingSystemScript.playerSpeed;
        ScoreText = textObject;
        inGameBullets = UnpgradingSystemScript.playerBulletsCount + 1;
    }

    // Update is called once per frame
    void Update()
    {
        BullestsText.GetComponent<TextMesh>().text = "Bullest: " + inGameBullets;
        InGameBullets = inGameBullets;
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

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
        }
        if (Input.touches.Length == 0)
        {
            canShot = true;
        }
    }
}
