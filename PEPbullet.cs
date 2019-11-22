using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEPbullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float bulletSpeed = 5f;
    Rigidbody2D rb;
    float finalSpeed;
    
    GameObject player;
    Vector3 currentPlayerPos;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        /*if (player)
            currentPlayerPos = player.transform.position;
        finalSpeed = bulletSpeed * Time.deltaTime;*/

        moveDirection = (player.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        /*transform.LookAt(currentPlayerPos);
        transform.position = Vector3.MoveTowards(transform.position, currentPlayerPos, finalSpeed);
        if (transform.position == currentPlayerPos)
        {
          
            Destroy(gameObject);
        }*/
    }
    void OnCollision2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
