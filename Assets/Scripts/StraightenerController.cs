using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightenerController : MonoBehaviour
{
    public float speed = 3000.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //public bool pressed = false;
    //public GameObject projectilePrefab;
    private Camera cam;
    Vector2 mousePos = new Vector2();
    I_Grabbable louse = null;
    [SerializeField] AudioSource StraightenerPressed;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

       //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        if (Input.GetMouseButtonDown(0))/*MouseButtonDown(0)*/
        {
            StraightenerPressed.Play();
            animator.SetTrigger("pressed");
            if (louse != null)
            {
                louse.grab();
                louse = null;
            }
            //animator.SetTrigger("pressed1");
        }

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position; // this is for the x and y values
        if (mousePos.x > 102)
        {
            mousePos.x = 102;
        }
        position.x = mousePos.x;
        position.y = mousePos.y;
        rigidbody2d.MovePosition(position);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        louse = other.gameObject.GetComponent<I_Grabbable>();
        //Debug.Log(other.gameObject.name);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        louse = null;
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    I_Grabbable louse = other.gameObject.GetComponent<I_Grabbable>();

    //    if (louse != null && pressed == true)
    //   {
    //        louse.grab();
    //    }
    //    pressed = false;
    //}
}
