using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitController : MonoBehaviour, I_Grabbable
{
    public bool vertical = false;
    public float changeTime = 5.0f;
    [SerializeField] Lice No_of_lice;
    Rigidbody2D rigidbody2D;
    [SerializeField] float timer;
    [SerializeField] float speed = 0.1f;
    [SerializeField] Score scoredata;
    public GameObject gameObject1;
    int clicked = 0;
    bool missed = false;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            missed = true;
            timer = changeTime;
        }
        if (missed == true)
        {
            Destroy(gameObject1);
            No_of_lice.increment_Lice_Number(5);
            missed = false;
        }
    }

    public void grab()
    {
        if (clicked == 3)
        {
            Destroy(gameObject1);
            scoredata.add_score(21);
            clicked = 0;
        }
        else if (clicked < 3)
        {
            clicked++;
        }
    }
}
