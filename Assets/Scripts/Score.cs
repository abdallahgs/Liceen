using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Abdallah/ScoreData",order = 1)]
public class Score : ScriptableObject
{

    [System.NonSerialized] int scoreVal = 0;
    
    public void set_score(int i_score)
    {
        scoreVal = i_score;
    }
    public void add_score(int i_score)
    {
        scoreVal += i_score;
    }
    public int ScoreValue => scoreVal;
}
