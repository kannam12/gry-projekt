using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;   //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis
    public Rigidbody2D rb;
    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

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
        if (other.gameObject.CompareTag("Falling"))
        {
            Debug.Log("You lose");
            SceneManager.LoadScene("Scenes/GameOver");
        }
        else
        {
            Debug.Log("not");
        }
    }

    void FixedUpdate() {
        if (Timer.instance.timerIsRunning)
        {
            rb.MovePosition(rb.position + movement * (movementSpeed * Time.fixedDeltaTime));
        }

    }



}
