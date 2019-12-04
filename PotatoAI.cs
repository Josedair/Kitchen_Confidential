using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoAI : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 45f;
    public float chaseRange;
    
    public SpriteRenderer potatoBoss;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindWithTag("Player");
    rb = this.GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.localPosition.x - transform.localPosition.x <= 0)
        {
            potatoBoss.flipX = true;
        }
        else potatoBoss.flipX = false;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < chaseRange)
        {
            Vector3 direction = (player.transform.position - transform.position);
            direction.Normalize();
            movement = direction;
            moveEnemy(movement);
        }
    }

    void moveEnemy(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
