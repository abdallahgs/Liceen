using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherLiceController : MonoBehaviour , I_Grabbable
{
    /*[SerializeField] float speed = 0.1f;
    [SerializeField] Score scoredata;
    public GameObject gameObject1;
    int clicked = 0;
    //Animator animator;
    public float maxSpeed = 5f;
    public float rotationSpeed = 200f;
    public float changeDirectionInterval = 2f;
    [SerializeField] float minYValue = 1f;
    [SerializeField] float maxYValue = 12.5f;
    [SerializeField] float minXValue = 72f;
    [SerializeField] float maxXValue = 102f;
    [SerializeField] float minYValue2 = 12.5f;
    [SerializeField] float maxYValue2 = 20.5f;
    [SerializeField] float minXValue2 = 75.5f;
    [SerializeField] float maxXValue2 = 97.55f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    float elapsedTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        elapsedTime = 0f;
        moveDirection = Random.insideUnitCircle.normalized;  // Start with a random direction
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeDirectionInterval || ChangeDirection())
        {
            moveDirection = Random.insideUnitCircle.normalized;
            elapsedTime = 0f;
        }
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Mathf.MoveTowardsAngle(rb.rotation, angle, rotationSpeed * Time.deltaTime);
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection * speed);
        }

        // Clamp bug's position within the specified y-direction and x-direction values
        Vector3 clampedPosition = transform.position;
        if (clampedPosition.y < maxYValue)
        {
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minYValue, maxYValue);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minXValue, maxXValue);
        }
        else
        {
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minYValue2, maxYValue2);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minXValue2, maxXValue2);
        }
        transform.position = clampedPosition;
    }

    private bool ChangeDirection()
    {
        // Check if the bug is about to move outside the specified y-direction or x-direction values
        Vector3 nextPosition = transform.position + (Vector3)(moveDirection * speed * Time.deltaTime);
        return nextPosition.y < minYValue || nextPosition.y > maxYValue2 || (nextPosition.x < minXValue2 && nextPosition.y > maxYValue) || nextPosition.x > maxXValue
            || nextPosition.x < minXValue || (nextPosition.x > maxXValue2 && nextPosition.y > maxYValue);
    }*/
    public float speed = 4.0f;
    public bool vertical = true;
    public float changeTime = 3.0f;
    //public bool create = false; // for the generating of lice.
    [SerializeField] Score scoredata;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    public GameObject gameObject1;
    public GameObject gameObject2;
    Animator animator;
    bool missed = false;
    int randomvalue;//Random.Range(0, 3);
    //coroutines
    Coroutine c_laynits = null;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        randomvalue = Random.Range(0, 2);
        if (randomvalue == 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        c_laynits = StartCoroutine(laynits(2));
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        animator.SetFloat("motherdirection", -1*direction);
        if (timer < 0)
        {
            timer = changeTime;
            missed = true;
        }
        if (missed == true)
        {
            Destroy(gameObject1);
            missed = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        //animator.SetFloat("moveX", direction);
        //animator.SetFloat("moveY", 0);
        rigidbody2D.MovePosition(position);
    }
    public void grab()
    {
       // Destroy(gameObject1);
       // scoredata.add_score(5);
        return;
    }
    IEnumerator laynits(int t)
    {
        for (int i = 0; i < t; i++)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(gameObject2, (transform.position-(-2*Vector3.left*direction)) , Quaternion.identity);
        }
    }
    void cancelmovement()
    {
        if (c_laynits != null)
        {
            StopCoroutine(c_laynits);
        }
        c_laynits = null;

    }
}
