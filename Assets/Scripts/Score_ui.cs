using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_ui : MonoBehaviour
{
    Text Scoretext;
    [SerializeField] Score scoredata;
    void Start()
    {
        Scoretext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = " " + scoredata.ScoreValue;
    }
}
