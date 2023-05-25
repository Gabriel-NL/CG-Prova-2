using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenBot : MonoBehaviour
{



    public bool grounded;
    public Rigidbody rb;

    //N�o usei essa fun��o, mas se quiser edite a vontade
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
    }

    //Quando tocar no ch�o, grounded se torna falso
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "GroundTag")
        {
            grounded = false;
        }
    }


    void Update()
    {
        //Aviso: Por algum motivo,
        //Toda vez que a gravidade � aplicada no rigid body
        //O root motion para de funcionar
        //Ent�o criei um codigo que faz a gravidade ser aplicada
        //Somente quando ele n�o tocar no ch�o
        if (grounded==false)
        {
        rb.AddForce(Vector3.down * 30);
            
        }
    }


}
