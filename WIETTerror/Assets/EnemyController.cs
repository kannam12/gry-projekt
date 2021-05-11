using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Vector2 patrolTarget;

    private enum State
    {
        Attack,
        Patrol
    }

    private State currentState;
    private float speed = 0.0001f;
    private Vector2 initialPosition;
    private Vector2 currentTarget;
    public bool turnBack;
    //public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Patrol;
        initialPosition = new Vector2(transform.position.x, transform.position.y);
        currentTarget = patrolTarget;
        //if (rb == null)
        //{
           // rb = GetComponent<Rigidbody2D>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (currentState == State.Patrol)
        {
            Debug.Log(currentTarget);
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), currentTarget, step);
            //rb.MovePosition(rb.position + currentTarget * (speed * Time.fixedDeltaTime));

           // Vector2 toTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);
            
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), currentTarget) < 0.2f)
            //if (toTarget.magnitude < 0.5f)
            {
                Debug.LogError("turn back");
                currentTarget = currentTarget == patrolTarget ? initialPosition : patrolTarget;
            }
        }
        else
        {
            //attack
        }
        */
    }
    
    void FixedUpdate() {
        if (currentState == State.Patrol)
        {
            Debug.Log(currentTarget);
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.Lerp(currentPosition, currentTarget, step);
            //rb.MovePosition(rb.position + currentTarget * (speed * Time.fixedDeltaTime));

           // Vector2 toTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);
            
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), currentTarget) < 0.2f)
            //if (toTarget.magnitude < 0.5f)
            {
                Debug.LogError("turn back");
                currentTarget = currentTarget == patrolTarget ? initialPosition : patrolTarget;
            }
        }
        else
        {
            //attack
        }
    }

    public void onSpotted()
    {
        currentState = State.Attack;
    }
}
