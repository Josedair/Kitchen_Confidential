using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 45f;
    public float chaseRange;

    // Animation Stuff
    private AnimationState animationState = AnimationState.NONE;
    private Animator animator;

    public enum AnimationState
    {
        NONE = 0,
        IDLE = 1,
       WIGGLE =2
    };
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animationState = AnimationState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        

    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
      
        if (distanceToPlayer < chaseRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            moveEnemy(movement);
            animationState = AnimationState.WIGGLE;

        }
       
    }
    void cheeseWiggle()
    {
        switch (animationState)
        {
           case AnimationState.NONE:
                animator.SetBool("isIdling", true);
                animator.SetBool("isMoving", false);
                break;


            case AnimationState.WIGGLE:
                animator.SetBool("isIdling", false);
                animator.SetBool("isMoving", true);
                break;
        }
    }
}
