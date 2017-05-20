using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreateEnemyScript : MonoBehaviour
{

    public static List<GameObject> enemyObjectList;
    GameObject spawnPointObject;
    public GameObject enemyObject;
    //public float Start_TimeDealay;
    public float lastSpawn;
    float timeDealay;
    int correntLevel = 0;

    // Use this for initialization
    void Start()
    {
        spawnPointObject = this.gameObject.transform.GetChild(0).gameObject;
        //the time in seconds sines the game started
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn <= Time.time)
        {
            float X = Random.Range(this.transform.position.x - this.transform.localScale.x / 2f + enemyObject.transform.localScale.x, this.transform.position.x + this.transform.localScale.x / 2f - enemyObject.transform.localScale.x);
            Vector3 spawnPositon = new Vector3(X, spawnPointObject.transform.position.y, 0);
            //spawn Enemy
            GameObject holder = Instantiate(enemyObject);
            holder.transform.position = spawnPositon;
            holder.GetComponent<EnemyScript>().speedForce = holder.GetComponent<EnemyScript>().speedForce + ((correntLevel - 1) * 5);
            //Zero time
            lastSpawn = Time.time + timeDealay;
            timeDealay = timeDealay - timeDealay / 50f;
            if (timeDealay <= 0.75f)
            {
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        print("next level - " + correntLevel.ToString());
        correntLevel++;
        timeDealay = 3.5f;
    }
}
