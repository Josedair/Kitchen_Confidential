using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEPjoint : MonoBehaviour
{
   public GameObject pepHead;
    [SerializeField]
    private float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
              pepHead.transform.position,
              moveSpeed * Time.deltaTime);
    }
}
