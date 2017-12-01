using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float AP = 50;

    // Nothing
    void Start()
    {
        AP = UpgradingSystemScript.playerPower;
    }

    // Nothing
    void Update()
    {

    }

    //bullet hits - enemy/mother ship = life down, wall = destroy bullet => hits enemy just if the same color
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collider.transform.tag == "Enemy")
        {
            if (collider.GetComponent<Renderer>().material.color == this.GetComponent<Renderer>().material.color)
            {
                collider.gameObject.GetComponent<EnemyScript>().HP = collider.transform.GetComponent<EnemyScript>().HP - this.AP;
                Destroy(this.gameObject);
            }
        }
        if (collider.transform.tag == "MotherShip")
        {
            collider.gameObject.GetComponent<MotherShipScript>().HP = collider.transform.GetComponent<MotherShipScript>().HP - this.AP;
        }

    }

    //old bullet
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            //destroy
        }
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().HP = collision.transform.GetComponent<EnemyScript>().HP - this.AP;
        }
        if (collision.transform.tag == "MotherShip")
        {
            collision.gameObject.GetComponent<MotherShipScript>().HP = collision.transform.GetComponent<MotherShipScript>().HP - this.AP;
        }
        if (collision.transform.tag != "Nothing")
        {
            Destroy(this.gameObject);
        }
    }
}


