using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweezersController : MonoBehaviour
{
    public float speed = 3000.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    private Camera cam;
    Vector2 mousePos = new Vector2();
    I_Grabbable louse = null;

    [SerializeField] AudioSource tweezersclicked;
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

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        if (Input.GetMouseButtonDown(0))
        {
            tweezersclicked.Play();
            animator.SetTrigger("pressed1");
            if (louse != null)
            {
                louse.grab();
                louse = null;
            }
        }

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
    }
  /*  void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;


        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        // mousePos.x = currentEvent.mousePosition.x+202.0f;
        // mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y+292.0f;


        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
    */
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
        louse= null;    
    }
}
