using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buttontweezers : MonoBehaviour
{
    //int counter = 0;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public void buttonclicked()
    {
        gameObject1.SetActive(true);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
       // Debug.Log("it's working");
    }
}
