using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float prox;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

        
        
    

    // Update is called once per frame
    void Update()
    {
       dist = Vector3.Distance(player.position, transform.position);

       if (dist <= prox)
       {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
       }
        
    }
}
