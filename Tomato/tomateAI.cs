using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomateAI : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 45f;
    public float chaseRange;
    public float shootRange;
    public SpriteRenderer tomateBoss;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.localPosition.x - transform.localPosition.x <= 0)
        {
            tomateBoss.flipX = true;
        }
        else tomateBoss.flipX = false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            Vector3 direction = -(player.position - transform.position);
            direction.Normalize();
            movement = direction;
            moveEnemy(movement);
        }

        //shootRange must be greater than chaseRange or else tomate will vibrate
        else if(distanceToPlayer > shootRange)
        {
            Vector3 direction = (player.position - transform.position);
            direction.Normalize();
            movement = direction;
            moveEnemy(movement);
        }
    }


    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
