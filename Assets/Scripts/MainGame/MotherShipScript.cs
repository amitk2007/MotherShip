using UnityEngine;
using System.Collections;

public class MotherShipScript : MonoBehaviour
{
    #region Variables
    public float max_HP = 100;
    public float HP;
    float barlength;

    GameObject HPBar;
    #endregion

    // Setting HP, setting the HP bar
    void Start()
    {
        HP = max_HP;
        HPBar = this.transform.Find("HealthBar").transform.Find("Bar").gameObject;
    }

    // Updating the HP bar by the mother ship HP
    void Update()
    {
        barlength = 1 - (max_HP - HP) / max_HP;
        HPBar.transform.localScale = new Vector3(barlength, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        if (HP <= 0 || PlayerScript.inGameBullets <= 0)
        {
            if (GameObject.FindGameObjectsWithTag("Bullet").Length <= 0)
            {
                if (GameObject.FindGameObjectsWithTag("Coin").Length <= 0)
                {
                    Application.LoadLevel("Menu");
                }
            }
        }
    }
}
