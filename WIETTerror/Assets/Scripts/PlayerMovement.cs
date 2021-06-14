using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f; //Movement Speed of the Player
    public Vector2 movement; //Movement Axis
    public Rigidbody2D rb;
    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;
    [SerializeField] private AudioSource waterSound;

    float pointRate;
    float nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        pointRate = 0.5f;
        nextPoint = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.instance.timerIsRunning)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;

            hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
            vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
            if (movement.x < -0.01f)
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }

            anim.SetFloat("Horizontal", hf);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", vf);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {

            waterSound.Play();
            movementSpeed = 0.2f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Water"))
            {
                Debug.Log("You exit");
                waterSound.Play();
                movementSpeed = 1f;
            }

        }



        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Water"))
            {

                //waterSound.Play();
                movementSpeed = 0.2f;
            }

            if (other.gameObject.CompareTag("Lava"))
            {
                if (Time.time > nextPoint)
                {
                    nextPoint = Time.time + pointRate;
                    ScoreManager.instance.ChangeECTSPoints();
                    Debug.Log("tyle czasu minelo" + nextPoint);
                }
            }
        }


        void FixedUpdate()
        {
            if (Timer.instance.timerIsRunning)
            {
                rb.MovePosition(rb.position + movement * (movementSpeed * Time.fixedDeltaTime));
            }

        }



    
}
