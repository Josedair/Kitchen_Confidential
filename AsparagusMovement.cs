using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsparagusMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 45f;
    public float chaseRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        bool inRange = false;
        if (distanceToPlayer < chaseRange)
        {

            inRange = true;
            chaseRange = 100;


        }

        if (inRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            moveEnemy(movement);
        }
    }
}
