using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepMovement : MonoBehaviour
{
    // Array of waypints for enemy to follow
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 5f;

    

    private int WPindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //moves enemy to waypoint1
        //transform.position = waypoints[WPindex].transform.position;
        Move();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move enemy
        Move();
    }

    private void Move()
    {
        /*if (WPindex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[WPindex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[WPindex].transform.position)
            {
                WPindex += 1;
            }
            if (WPindex <= waypoints.Length - 1)
            {
                WPindex = 0;
            }
        }*/

        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (WPindex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[WPindex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[WPindex].transform.position)
            {
                WPindex += 1;
                Debug.Log(WPindex);
            }

            if (WPindex == waypoints.Length)
            {
                WPindex = 0;
            }
        }
    }
}