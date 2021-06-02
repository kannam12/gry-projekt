using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform FirePoint;
    private Rigidbody2D rb;
    private float timer;
    public GameObject bulletPrefab;
    PlayerMovement target;
    Vector2 moveDirection;
    public float bulletForce = 10f;
    float fireRate;
    float nextFire;
    
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
        if (Time.time > nextFire) {
   
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);

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

