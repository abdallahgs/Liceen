using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombController : MonoBehaviour
{
    // serialized transform // instaniate(gameobject, Transform)
    [SerializeField] float speed = 1.0f;
    [SerializeField] float delay = 20.0f;
    [SerializeField] float lice_delay = 1.0f;
    [SerializeField] Vector3 startposition;
    [SerializeField] float endmovement_y = 8.0f;


    Rigidbody2D rigidbody2d;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    Animator animator;
    //LiceMovement LiceController;

    Coroutine c_combloop = null;
    Coroutine c_instantiatelice = null;
    Coroutine c_waitandstartcombanimation = null;

    [SerializeField] Lice No_of_lice;


    void Start()
    {
       animator = GetComponent<Animator>();
       rigidbody2d = GetComponent<Rigidbody2D>();
       animator.SetFloat("Comb", 0);
       c_combloop = StartCoroutine(CombLoop(speed, startposition,endmovement_y));
    }
    IEnumerator CombLoop(float i_combspeed, Vector3 i_startposition, float i_endmovement_y)
    {

        while (true)
        {
            transform.position = i_startposition;
            yield return new WaitForSeconds(1f);
            animator.SetFloat("Comb", 1);
            // comb movement starts here
            // cyclic lice instantiation starts here

            c_instantiatelice = StartCoroutine(instantiatelice(lice_delay));
            yield return new WaitForSeconds(2.0f);
            while (transform.position.y >= i_endmovement_y)
            {
                transform.position += Vector3.down * i_combspeed * Time.deltaTime;
                yield return null;
            }
            animator.SetFloat("Comb", 0);
            StopCoroutine(c_instantiatelice);
            c_instantiatelice = null;

            // comb movement ends here
            // cyclic lice instantiation ends here
        }
    }
    IEnumerator waitandstartcombanimation(float i_delay)
    {
            animator.SetFloat("Comb", 1);
            yield return new WaitForSeconds(i_delay);
            animator.SetFloat("Comb", 0);
            animator.SetTrigger("slide");
    }
    IEnumerator instantiatelice(float i_delay)
    {
        yield return new WaitForSeconds(i_delay);
        while (true)
        {
            int count = Random.Range(0, 3);
            if (count == 0)
            {
                Instantiate(gameObject1, transform.position, Quaternion.identity);
                Instantiate(gameObject2, transform.position, Quaternion.identity);
                Instantiate(gameObject2, transform.position, Quaternion.identity);
                No_of_lice.decrease_Lice_Number(3);
            }
            else if (count == 1)
            {
                Instantiate(gameObject3, transform.position, Quaternion.identity);
            }
            else if (count == 2)
            {
                Instantiate(gameObject4, transform.position, Quaternion.identity);
                No_of_lice.decrease_Lice_Number(1);
            }
            yield return new WaitForSeconds(i_delay);
        }
    }
    public void CancelMovement()
    {
        if (c_combloop != null)
        {
            StopCoroutine(c_combloop);
        }
        c_combloop = null;
        if (c_instantiatelice != null)
        {
            StopCoroutine(c_instantiatelice);
        }
        c_instantiatelice = null;
        if (c_waitandstartcombanimation != null)
        {
            StopCoroutine(c_waitandstartcombanimation);
        }
        c_waitandstartcombanimation = null;
    }
}
