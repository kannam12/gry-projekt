using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour {
    public Transform FirePoint;
    private Rigidbody2D rb;
    private float timer;
    public GameObject bulletPrefab;
    PlayerMovement target;
    public Transform enemy1;
    Vector2 moveDirection;
    public float bulletForce = 3f;
    float fireRate;
    float nextFire;
    float lifetime = 4f;
    Vector2 Distance;
    float DistanceFrom;
    private Rigidbody2D playerRb;

    void Start () {
        fireRate = 1f;
        nextFire = Time.time;
        playerRb = FindObjectOfType<PlayerMovement>().rb;
    }
    /*void Start () {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletForce;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy (gameObject, 3f);
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals ("Player")) {
            Debug.Log ("Hit!");
            Destroy (gameObject);
        }
    }*/
    //Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector2 targetPos = playerRb.position;
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

        float distance = (targetPos - currentPosition).magnitude;
        //Debug.Log(distance);

        if (distance < 0.2f)
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        
        if (distance < 3 && timer > 2)
        {
            //Debug.LogError("Shooting");
            Shoot();
        }

    }
    

    void Shoot()
    {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                //rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
                Vector2 targetPos = FindObjectOfType<PlayerMovement>().rb.position;
                Vector2 toTarget = (targetPos - rb.position).normalized;
                
                rb.AddForce(toTarget * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, lifetime);
     

            }
        
        /*
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletForce;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy (gameObject, 3f);
        */
    }
}

