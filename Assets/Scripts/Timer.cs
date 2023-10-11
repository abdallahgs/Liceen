using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TimeRemaining;
    public bool TimeIsRunnig;
    public TMP_Text TimeText;
    //public string LeveltoLoad;
    // Start is called before the first frame update
    void Start()
    {
        TimeIsRunnig = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeIsRunnig)
        {
            if(TimeRemaining >= 0)
            {
                TimeRemaining += Time.deltaTime;
                DisplayTime(TimeRemaining);
            }
        }
    }
    void DisplayTime(float TimetoDisplay)
    {
        TimetoDisplay += 1;
        float minutes = Mathf.FloorToInt(TimetoDisplay / 60);
        float seconds = Mathf.FloorToInt(TimetoDisplay % 60);
        TimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if (TimetoDisplay > 90)
        {
            //Application.LoadLevel(LeveltoLoad);
            SceneManager.LoadScene("FaintedScene");
        }
    }
}
