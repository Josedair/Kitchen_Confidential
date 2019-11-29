using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOMbullet : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    float bulletSpeed = 5f;
    Rigidbody2D rb;
    float finalSpeed;

    GameObject playerObject;
    Vector3 currentPlayerPos;
    Vector2 moveDirection;

    public SpriteRenderer sauce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (playerObject.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 1f);

        if (GameObject.FindGameObjectWithTag("Player").transform.localPosition.x - transform.localPosition.x <= 0)
        {
            sauce.flipX = true;
        }
        else sauce.flipX = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        Destroy(gameObject, 1.5f);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
