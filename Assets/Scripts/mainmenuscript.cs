using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainmenuscript : MonoBehaviour
{
    float delay = 2f;
    Coroutine c_startthegame = null;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
        //cancelmovement();
        //c_startthegame = StartCoroutine(startthegame(delay));
    }
    IEnumerator startthegame(float i_delay)
    {
        gameObject1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameObject2.SetActive(false);
        yield return new WaitForSeconds(i_delay);
        SceneManager.LoadScene("MainScene");
    }
    public void cancelmovement()
    {
        if(c_startthegame != null)
        {
            StopCoroutine(c_startthegame);
        }
        c_startthegame = null;
    }
}
