using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlowTorchController : MonoBehaviour
{
    public float speed = 3000.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    //Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //public bool pressed = false;
    //public GameObject projectilePrefab;
    private Camera cam;
    Vector2 mousePos = new Vector2();
    I_Grabbable louse = null;
    public ParticleSystem fireeffect;

    [SerializeField] float delay;
    [SerializeField] AudioSource blowtorchpushed;
    Coroutine c_show_flame = null;
    int count=0;
    void Start()
    {
        //fireeffect.Stop();
        //fireeffect.Play();
        //animator = GetComponent<Animator>();
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
            //animator.SetTrigger("pressed");
            //fireeffect.Play();
            blowtorchpushed.Play();
            c_show_flame = StartCoroutine(show_flame(delay));
            //blowtorchpushed.Pause();
            if (louse != null)
            {
                count = 0;
                louse.grab();
                louse = null;
            }
            else
            {
                count++;
            }
            //animator.SetTrigger("pressed1");
            //fireeffect.Stop();
        }
        if (count ==15)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        //fireeffect.Stop();
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
    IEnumerator show_flame(float i_delay)
    {
        fireeffect.Play();
        yield return new WaitForSeconds(i_delay);
        fireeffect.Pause();
    }
}
