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
            Debug.Log(currentTarget);
            
            float step = speed * Time.deltaTime;
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.Lerp(currentPosition, currentTarget, step);

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), currentTarget) < 0.1f)
            {
                Debug.LogError("turn back");
                currentState = State.Idle;
                currentTarget = currentTarget == patrolTarget ? initialPosition : patrolTarget;
            }
        }
        else if (currentState == State.Idle)
        {
            Debug.Log(timer);
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
        
    }
    
    public void onSpotted()
    {
        currentState = State.Attack;
    }
}