using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    float coins = 1;
    float bullets = 5;
    public bool isBullets = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print("test");
        if (other.gameObject.tag == "MotherShip")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            if (isBullets == false)
            {
               UpgradingSystemScript.coins = UpgradingSystemScript.coins + coins;
            }
            else
            {
                PlayerScript.inGameBullets = PlayerScript.inGameBullets + bullets;
            }
            Destroy(this.gameObject);
        }

    }
}
