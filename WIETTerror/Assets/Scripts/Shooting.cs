using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    void Start () {
        fireRate = 1f;
        nextFire = Time.time;
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

        if (timer > 2)
        {
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

