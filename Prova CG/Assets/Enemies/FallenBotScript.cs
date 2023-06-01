using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenBotScript : MonoBehaviour
{


    [SerializeField] public GameObject player;
    public bool grounded=false;
    public GameObject fallen;
    public Rigidbody rb;
    public float speed = 3.5f;
    
    void Start()
    {
       
    }

    //Quando tocar no ch�o, grounded se torna verdadeiro
    private void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "GroundTag")
        {
            grounded = true;

        }
        if (c.gameObject.tag == "Spell")
        {
            Destroy(fallen);
        };
    }

    //Quando tocar no ch�o, grounded se torna falso
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "GroundTag")
        {
            grounded = false;
        }
    }

    public void setTarget(GameObject player) { this.player = player; }
    void Update()
    {
        //Aviso: Por algum motivo,
        //Toda vez que a gravidade e aplicada no rigid body
        //O root motion para de funcionar
        //Entao criei um codigo que faz a gravidade ser aplicada
        //Somente quando ele nao tocar no ch�o
        transform.LookAt(player.gameObject.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (grounded==false)
        {
            rb.AddForce(Vector3.down * 30);
            
        }
        if (fallen.transform.position.y < -10)
        {
            Destroy(fallen);
        }

    }


}
