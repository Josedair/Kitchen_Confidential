using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POTdeath : MonoBehaviour
{
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public GameObject potato1;
    public GameObject potato2;
    public float expirationTime;
    // Start is called before the first frame update
    void Start()
    {
        expirationTime = Time.time + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= expirationTime)
        {
            potDeath();
        }
    }

    public void potDeath()
    {
        Instantiate(potato1, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(potato2, spawnpoint2.position, spawnpoint2.rotation);
        Destroy(gameObject);
    }
}
