using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "LiceNumber", menuName = "Abdallah/LiceNumber", order = 2)]

public class Lice : ScriptableObject
{
    [System.NonSerialized] int LiceNum = 50;
    public void decrease_Lice_Number(int i_score)
    {
        LiceNum = LiceNum - i_score;
    }
    public void increment_Lice_Number(int i_score)
    {
        LiceNum = LiceNum + i_score;
    }
    public void set_Lice_Number(double i_score)
    {
        LiceNum = (int)Mathf.Floor((float)i_score);
    }
    public int getter_LiceNum => LiceNum;

}
