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

    #endregion

    // Use this for initialization
    void Start()
    {
        ScoreText = textObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

        if (Input.touches.Length > 0)
        {
            if (canShot)
            {
                Vector3 a = this.transform.position;
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
            }
        }
        if (Input.touches.Length == 0)
        {
            canShot = true;
        }
    }
}
