using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilcollider : MonoBehaviour // sistema para colisão de projéteis
{
    private bool collided;
    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player")
        {
            collided = true;
            Destroy (gameObject);   
        }
    }

}