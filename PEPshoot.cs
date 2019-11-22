using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEPshoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform Bulletspawn;
    //GameObject spawn3;
    //GameObject spawn4;
    //GameObject spawn5;
    //GameObject spawn6;

    float fireRate = 2f;
    float nextFire;

    void Start()
    {
        
        float nextFire= Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, Bulletspawn.position, Bulletspawn.rotation  );
            nextFire = Time.time + fireRate;
        }
    }
}
