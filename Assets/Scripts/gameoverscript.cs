using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    //public Text pointstext;
    //public void setup(int score)
    //{
    //    gameObject.SetActive(true);
    //     pointstext.text = score.ToString() + "POINTS";
    //}
   // [SerializeField] Score scoredata;
   // Text Scoretext;
   // void Start()
   // {
   //     Scoretext = GetComponent<Text>();
   //     Scoretext.text = " " + scoredata.ScoreValue;
   // }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ExitButton()
    {
    SceneManager.LoadScene("MainMenu");
    }
}
