using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiceMovement : MonoBehaviour, I_Grabbable
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float delay = 2f;
    [SerializeField] Score scoredata;
    public GameObject gameObject1;
    int clicked = 0;
    //Animator animator;
    public float maxSpeed = 5f;
    public float rotationSpeed = 200f;
    public float changeDirectionInterval = 2f;
    [SerializeField] float minYValue = -0.5f;
    [SerializeField] float maxYValue = 11.4f;
    [SerializeField] float minXValue = 72f;
    [SerializeField] float maxXValue = 100f;
    [SerializeField] float minYValue2 = 11.4f;
    [SerializeField] float maxYValue2 = 21.9f;
    [SerializeField] float minXValue2 = 75.5f;
    [SerializeField] float maxXValue2 = 97.55f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    float elapsedTime;
    Animator animator;
    public float changeTime = 10.0f;
    [SerializeField] Lice No_of_lice;
    [SerializeField] float timer;
    bool missed = false;
    int direction = 1;
    bool grabbed = false;
    Coroutine c_grabbedalice = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        elapsedTime = 0f;
        moveDirection = Random.insideUnitCircle.normalized;  // Start with a random direction
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            missed = true;
            direction = -direction;
            timer = changeTime;
        }
        if (missed == true)
        {
            Destroy(gameObject1);
            No_of_lice.increment_Lice_Number(1);
            missed = false;
        }
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
        //animator.SetFloat("moveX", direction);
        //animator.SetFloat("moveY", direction);
        transform.position = clampedPosition;
    }

    private bool ChangeDirection()
    {
        // Check if the bug is about to move outside the specified y-direction or x-direction values
        Vector3 nextPosition = transform.position + (Vector3)(moveDirection * speed * Time.deltaTime);
        return nextPosition.y < minYValue || nextPosition.y > maxYValue2 || (nextPosition.x < minXValue2 && nextPosition.y > maxYValue) || nextPosition.x > maxXValue
            || nextPosition.x < minXValue || (nextPosition.x > maxXValue2 && nextPosition.y > maxYValue);
    }
    /*public float speed = 4.0f;
    public bool vertical = true;
    public float changeTime = 3.0f;
    [SerializeField] Score scoredata;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    public GameObject gameObject;
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // this is for the movement of the louse
        /*timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            count++;
        }
        if (count == 2)
        {
            vertical = !vertical;
            count = 0;
        }* / // the previous 13lines of code were a comment 
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            //animator.SetFloat("moveX", 0);
            //animator.SetFloat("moveY", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            //animator.SetFloat("moveX", direction);
            //animator.SetFloat("moveY", 0);
        }
        rigidbody2D.MovePosition(position);
    }*/
    public void grab()
    {
        scoredata.add_score(5);
        Destroy(gameObject);
    }
}
