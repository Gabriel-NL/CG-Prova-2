using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class FallenBot : MonoBehaviour
{


    public GameObject player;
    private UnityEngine.AI.NavMeshAgent navMesh;
    public bool grounded=false;
    public Rigidbody rb;

    //Não usei essa função, mas se quiser edite a vontade
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    //Quando tocar no chão, grounded se torna verdadeiro
    private void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "GroundTag")
        {
            grounded = true;

        }
    }

    //Quando tocar no chão, grounded se torna falso
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
        //Toda vez que a gravidade é aplicada no rigid body
        //O root motion para de funcionar
        //Então criei um codigo que faz a gravidade ser aplicada
        //Somente quando ele não tocar no chão
        navMesh.destination = player.transform.position;
        if (grounded==false)
        {
            rb.AddForce(Vector3.down * 30);
            
        }
    }


}
