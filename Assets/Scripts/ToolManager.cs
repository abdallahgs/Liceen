using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolManager : MonoBehaviour
{
    [SerializeField] Lice No_of_lice;
    [SerializeField] float delay;
    //Animator animator;
    
    public GameObject Tweezers_Game_Object;
    public GameObject Straightener_Game_Object;
    public GameObject Blow_Torch_Game_Object;
    public GameObject Spray_Game_Object;
    public GameObject Spray_Message;
    public GameObject tweezersbuttonclicked;
    public GameObject straightenerbuttonclicked;
    public GameObject blowtorchbuttonclicked;
    public GameObject spraybuttonclicked;

    bool gas_Was_used = false;
    //int tenpercent = No_of_lice.getter_LiceNum;

    //coroutines
    Coroutine c_show_Spray_message = null;
    Coroutine c_reset = null;
    Coroutine c_buttonclickedicon = null;
    public void Spray_Clicked()
    {
        double nintypercent = No_of_lice.getter_LiceNum * 0.9;
        CancelMovement();
        if (No_of_lice.getter_LiceNum>90)
        {
            Spray_Message.SetActive(true);
            c_show_Spray_message = StartCoroutine(Show_Spray_message(delay));
        }
        else
        {
            // animator.SetTrigger("button_pressed");
            Tweezers_Game_Object.SetActive(false);
            Straightener_Game_Object.SetActive(false);
            Blow_Torch_Game_Object.SetActive(false);
            Spray_Game_Object.SetActive(true);
            gas_Was_used = true;
            No_of_lice.set_Lice_Number(nintypercent);
            c_reset = StartCoroutine(reset(delay));
            c_buttonclickedicon = StartCoroutine(buttonclickedicon(spraybuttonclicked, delay));
        }
    }
    public void Tweezers_Clicked()
    {
        Tweezers_Game_Object.SetActive(true);
        Straightener_Game_Object.SetActive(false);
        Blow_Torch_Game_Object.SetActive(false);
        Spray_Game_Object.SetActive(false);
        gas_Was_used = false;
        c_buttonclickedicon = StartCoroutine(buttonclickedicon(tweezersbuttonclicked, 2*delay));
    }
    public void Straightener_Clicked()
    {
        Tweezers_Game_Object.SetActive(false);
        Straightener_Game_Object.SetActive(true);
        Blow_Torch_Game_Object.SetActive(false);
        Spray_Game_Object.SetActive(false);
        gas_Was_used = false;
        c_reset = StartCoroutine(reset(2*delay));
        c_buttonclickedicon = StartCoroutine(buttonclickedicon(straightenerbuttonclicked, 2*delay));
    }
    public void Blow_Torch_Clicked()
    {
        if (gas_Was_used)
        {
            SceneManager.LoadScene("ExpScene");
        }
        Tweezers_Game_Object.SetActive(false);
        Straightener_Game_Object.SetActive(false);
        Blow_Torch_Game_Object.SetActive(true);
        Spray_Game_Object.SetActive(false);
        gas_Was_used = false;
        c_reset = StartCoroutine(reset(2*delay));
        c_buttonclickedicon = StartCoroutine(buttonclickedicon(blowtorchbuttonclicked, 2*delay));
    }
    IEnumerator Show_Spray_message(float i_delay)
    {
        yield return new WaitForSeconds(i_delay);
        Spray_Message.SetActive(false);
    }
    IEnumerator reset(float i_delay)
    {
        yield return new WaitForSeconds(i_delay);
        Tweezers_Game_Object.SetActive(true);
        Straightener_Game_Object.SetActive(false);
        Blow_Torch_Game_Object.SetActive(false);
        Spray_Game_Object.SetActive(false);
    }
    IEnumerator buttonclickedicon(GameObject gameObject, float i_delay)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(i_delay);
        gameObject.SetActive(false);
    }
    public void CancelMovement()
    {
        if (c_show_Spray_message != null)
        {
            StopCoroutine(c_show_Spray_message);
        }
        c_show_Spray_message = null;
        if (c_reset != null)
        {
            StopCoroutine(c_reset);
        }
        c_reset = null;
        if (c_buttonclickedicon != null)
        {
            StopCoroutine(c_buttonclickedicon);
        }
        c_buttonclickedicon = null;
    }
    }
