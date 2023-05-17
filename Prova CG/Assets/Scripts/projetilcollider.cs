using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilcollider : MonoBehaviour // sistema para colisão de projéteis e o seu impacto
{
    public GameObject impactoVFX;
    public AudioSource audioPlayer;
   
    private bool collided;
    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player")
        {
            collided = true;

            var impact = Instantiate (impactoVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy (impact, 2);

            Destroy (gameObject);   
            audioPlayer.Play();

            
        }
    }

}