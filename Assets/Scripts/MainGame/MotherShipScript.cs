using UnityEngine;
using System.Collections;

public class MotherShipScript : MonoBehaviour
{
    #region variables
    public float max_HP = 100;
    public float HP;

    float barlength;
    GameObject HPBar;

    #endregion

    // Setting HP, setting the HP bar
    void Start()
    {
        HP = max_HP;
        HPBar = this.transform.FindChild("HealthBar").transform.FindChild("Bar").gameObject;
    }

    // Updating the HP bar by the mother ship HP
    void Update()
    {
        barlength = 1 - (max_HP - HP) / max_HP;
        HPBar.transform.localScale = new Vector3(barlength, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        if (HP <= 0|| PlayerScript.InGameBullets <= 0)
        {
            Application.LoadLevel("Menu");
        }
    }
}
