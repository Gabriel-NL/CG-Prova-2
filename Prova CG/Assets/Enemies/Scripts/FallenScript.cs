using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallenScript : MonoBehaviour {

    //Variaveis
    private int pontosDeVida = 6;
    private float stoppingDistance = 2.4f;
    private bool grounded = false;

    private float distance;

    //Scripts
    public Horda horda;

    //Componentes
    public GameObject fallen;
    private Animator animator;
    public GameObject player;
    private NavMeshAgent navMesh;
    private Rigidbody rb;

    //Start is called before the first frame update
    void Start() {

        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb= GetComponent<Rigidbody>();
        navMesh.stoppingDistance = stoppingDistance;
        
        animator.SetBool("correr", true);        
        animator.SetBool("tocando_player", false);
    }

    public void setTarget(GameObject player) { this.player = player; }
    public void setHP(int horda) { this.pontosDeVida = 8 + 10 * (horda-1); }
    public void RecebendoDano(int dano){this.pontosDeVida -= dano;}
    public void setHorda(Horda horda) { this.horda = horda; }

    //Update is called once per frame
    void Update() {

        if (grounded == false)
        {
            rb.AddForce(Vector3.down * 30);
        }

        navMesh.destination =
            player.transform.position;
        distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distanceToTarget.ToString());


        if(distance > navMesh.stoppingDistance){
            animator.SetBool("tocando_player", false);


        }

        if(distance <= navMesh.stoppingDistance)
        {
            animator.SetBool("tocando_player", true);
            animator.SetBool("correr", false);
            animator.SetTrigger("atacar");
            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;

        }

        if (fallen.transform.position.y < -10 || this.pontosDeVida<=0)
        {
            if (this.horda != null){this.horda.FallenMorto();}
            
            Destroy(fallen);
        }


    }


    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("GroundTag"))
        {
            grounded = true;
        }

        if (c.collider.CompareTag("Player")) 
        {

        }
    }

    //Quando tocar no ch�o, grounded se torna falso
    private void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("GroundTag"))
        {
            grounded = false;
        }
    }

    public void AtacouAlvo()
    {
        if (animator.GetBool("tocando_player"))
        {
            Controlador controlador= player.GetComponent<Controlador>();
            controlador.pd.TomouDano();
        }
    }
    public void Atacando()
    {
        if (animator.GetBool("tocando_player"))
        {

            Debug.Log("AtacandoDenovo");
            animator.SetBool("correr", false);
            animator.SetTrigger("atacar");
        }
        else
        {
            animator.SetBool("correr", true);
            navMesh.isStopped = false;
            Debug.Log("Andando");
        }
    }
}
