using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LiceNumber_ui : MonoBehaviour
{
    Text LiceText;
    [SerializeField] Lice No_of_lice;
    public string LeveltoLoad;
    // Start is called before the first frame update
    void Start()
    {
        LiceText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LiceText.text = "      " + No_of_lice.getter_LiceNum;
        if (No_of_lice.getter_LiceNum <= 0)
        {
            Application.LoadLevel(LeveltoLoad);
        }
    }
}
