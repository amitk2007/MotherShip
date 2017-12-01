using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

public class CreateEnemyScript : MonoBehaviour
{
    GameObject spawnPointObject;
    public GameObject enemyObject;
    //public float Start_TimeDealay;
    public float lastSpawn;
    float timeDealay;

    float correntLevel = 0;
    float HPAdd;
    float speedAdd;
    float damageAdd;

    // Use this for initialization
    void Start()
    {
        //getting the corrent level
        correntLevel = UpgradingSystemScript.level;
        setLevel(correntLevel);
        spawnPointObject = this.gameObject.transform.GetChild(0).gameObject;
        //the time in seconds sines the game started
        lastSpawn = Time.time;

        //zero variabels to add to enemy
        HPAdd = 0;
        speedAdd = 0;
        damageAdd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //spwne enemy objects
        if (lastSpawn <= Time.time)
        {
            float X = Random.Range(this.transform.position.x - this.transform.localScale.x / 2f + enemyObject.transform.localScale.x, this.transform.position.x + this.transform.localScale.x / 2f - enemyObject.transform.localScale.x);
            Vector3 spawnPositon = new Vector3(X, spawnPointObject.transform.position.y, 0);
            //spawn Enemy
            GameObject holder = Instantiate(enemyObject);
            holder.transform.position = spawnPositon;
            holder.GetComponent<EnemyScript>().HP = holder.GetComponent<EnemyScript>().HP + HPAdd;
            holder.GetComponent<EnemyScript>().speedForce = holder.GetComponent<EnemyScript>().speedForce + speedAdd;
            holder.GetComponent<EnemyScript>().damageAP = holder.GetComponent<EnemyScript>().damageAP + damageAdd;

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
        PlayerPrefs.SetFloat("level", correntLevel);
        if (correntLevel % 3 == 0)
        {
            damageAdd = damageAdd + 2;
        }
        else if (correntLevel % 2 == 0)
        {
            HPAdd = HPAdd + 10;
        }
        else
        {
            speedAdd = speedAdd + 2;
        }
        timeDealay = 3.5f;
    }

    private void setLevel(float correntLevel)
    {
        for (int i = 0; i < correntLevel + 1; i++)
        {
            if (i % 3 == 0)
            {
                damageAdd = damageAdd + 2;
            }
            else if (i % 2 == 0)
            {
                HPAdd = HPAdd + 10;
            }
            else
            {
                speedAdd = speedAdd + 2;
            }
        }
        timeDealay = 3.5f;
    }
}
