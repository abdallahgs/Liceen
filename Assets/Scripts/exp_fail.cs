using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exp_fail : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
