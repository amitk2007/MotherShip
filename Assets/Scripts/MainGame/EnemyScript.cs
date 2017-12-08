using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    #region Variables
    public float max_HP = 100;
    public float speedForce;
    public float damageAP;
    public float HP;
    float barlength;

    public bool canShot = false;

    public GameObject[] powerUps;
    public GameObject bullet;
    GameObject HPBar;

    Time shotHelperTime;
    #endregion

    // Add force to the object, setting HP, setting the HP bar object, gives random color (0=blue,1=red)
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -speedForce, 0));

        HP = max_HP;
        HPBar = this.transform.Find("HealthBar").transform.Find("Bar").gameObject;
        if (Random.Range(0, 2) == 0)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Updating the HP bar by enemy's HP, adding score when die and destroing this object
    void Update()
    {
        barlength = 1 - (max_HP - HP) / max_HP;
        HPBar.transform.localScale = new Vector3(barlength, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
        if (HP <= 0)
        {
            PlayerScript.playerScore++;
            DropCoin();
            Destroy(this.gameObject);
        }
    }

    //if hits the mother ship take her HP down
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "MotherShip")
        {
            other.gameObject.GetComponent<MotherShipScript>().HP = other.gameObject.GetComponent<MotherShipScript>().HP - damageAP;

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Nothing")
        {
            canShot = true;
        }
    }
    public void shot()
    {
        if (canShot)
        {

        }
    }

    void DropCoin()
    {
        //drop power up
        if (Random.Range(1, 5) == 3)
        {
            print("coin test");
            if (Random.Range(1, 4) == 3)
            {
                GameObject powerup = Instantiate(powerUps[0], this.transform.position, Quaternion.identity);
                powerup.GetComponent<Rigidbody>().AddForce(Vector3.up * -20);
            }
        }
    }
}
