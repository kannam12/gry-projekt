using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Vector2 patrolTarget;

    private enum State
    {
        Idle,
        Attack,
        Patrol
    }

    private State currentState;
    private float speed = 0.5f;
    private Vector2 initialPosition;
    private Vector2 currentTarget;
    private float timer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool facingRight;

    /*
    private Rigidbody2D rb;
    private Transform target;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle;
        initialPosition = new Vector2(transform.position.x, transform.position.y);
        currentTarget = patrolTarget;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.Patrol)
        {
            // Debug.Log(currentTarget);
            
            float step = speed * Time.deltaTime;
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.Lerp(currentPosition, currentTarget, step);

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), currentTarget) < 0.1f)
            {
                // Debug.LogError("turn back");
                currentState = State.Idle;
                currentTarget = currentTarget == patrolTarget ? initialPosition : patrolTarget;
                if (currentTarget.x > patrolTarget.x)
                {
                    _spriteRenderer.flipX = false;
                }
                else if (currentTarget.x < patrolTarget.x)
                {
                    _spriteRenderer.flipX = true;
                }
                else
                {
                    return;
                }
            }
        }
        else if (currentState == State.Idle)
        {
            // Debug.Log(timer);
            timer += Time.deltaTime;

            if (timer > 2)
            {
                currentState = State.Patrol;
                
                timer = 0;
            }
        }
        else if (currentState == State.Attack)
        {
            //attack
        }
        //not working :(
        /*
        if (Vector2.Distance(target.position,transform.position)<20)
        {

            transform.position=Vector2.MoveTowards(transform.position, target.position,speed*Time.deltaTime);
            if(target.position.x > transform.position.x && !facingRight) 
                Flip();
            if(target.position.x < transform.position.x && facingRight)
                Flip();
        } 
        */
        
    }
    /*
    void Flip()
    {   
        //try with this true and false and maybe use currentTarget to check
        //_spriteRenderer.flipX = true;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    */
    
    public void onSpotted()
    {
        currentState = State.Attack;
    }
}