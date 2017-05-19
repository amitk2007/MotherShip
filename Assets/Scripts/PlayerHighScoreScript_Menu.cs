using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHighScoreScript_Menu : MonoBehaviour
{
    public static List<string> names = new List<string>();

    // Nothing
    void Start()
    {

    }

    // Nothing
    void Update()
    {

    }

    //Puts a name in a list in the right place by the high score
    public void SetPalyerPerfab(string newName, int NewScore)
    {
        bool isin = false;
        for (int i = 0; i < names.Count; i++)
        {
            if (isin == false)
            {
                if (PlayerPrefs.GetInt(names[i]) < NewScore)
                {
                    names.Insert(i, newName);
                    isin = true;
                }
            }
        }
        PlayerPrefs.SetInt(newName, 10);
    }

    // Going throw the names list and getting the score from each name
    public string[,] GetScores()
    {
        string[,] scores = new string[names.Count, 2];
        for (int i = 0; i < names.Count; i++)
        {
            scores[i, 0] = names[i];
            scores[i, 1] = PlayerPrefs.GetInt(names[i]).ToString();
        }
        return scores;
    }

    public bool IsNameExsist()
    {
        return false;
    }
}

