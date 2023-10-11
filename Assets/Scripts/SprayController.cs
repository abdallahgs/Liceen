using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    public float speed = 3000.0f;
    [SerializeField] float delay = 2.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1, 0);
    private Camera cam;
    Vector2 mousePos = new Vector2();
    I_Grabbable louse = null;

    public ParticleSystem gaseffect;
    [SerializeField] AudioSource spraypressed;
    Coroutine c_show_gas = null;
    void Start()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            c_show_gas = StartCoroutine(show_gas(delay));
            spraypressed.Play();
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
    }
    void OnTriggerExit2D(Collider2D other)
    {
        louse = null;
    }
    IEnumerator show_gas(float i_delay)
    {
        gaseffect.Play();
        yield return new WaitForSeconds(i_delay);
        gaseffect.Pause();
    }
}
