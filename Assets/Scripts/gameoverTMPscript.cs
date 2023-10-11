using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class gameoverTMPscript : MonoBehaviour
{
    TextMeshPro Scoretext;
    [SerializeField] Score scoredata;
    void Start()
    {
        Scoretext = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = " " + scoredata.ScoreValue;
    }
}
