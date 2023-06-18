using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallenScript : MonoBehaviour {

    //Variaveis
    private int pontosDeVida = 6;
    public float stoppingDistance = 0f;
    public bool grounded = false;
    public bool tocou_player;
    public bool pode_andar = true;

    //Scripts
    public Horda horda;

    //Componentes
    public GameObject fallen;
    private Animator animator;
    private GameObject player;
    private NavMeshAgent navMesh;
    private Rigidbody rb;

    //Start is called before the first frame update
    void Start() {
        tocou_player = false;

        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        rb= GetComponent<Rigidbody>();
        navMesh.stoppingDistance = stoppingDistance;
        fallen = gameObject;
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
        if (pode_andar)
        {
            animator.SetBool("correr", true);
            navMesh.isStopped = false;
        }
        else
        {

            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;
        }

        navMesh.destination = player.transform.position;
        float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distanceToTarget.ToString());

        if(distanceToTarget > navMesh.stoppingDistance){
        }

        if(distanceToTarget <= navMesh.stoppingDistance){
           

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
            tocou_player = true;
            animator.SetTrigger("atacar");
            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;
            pode_andar = false;
        }
    }

    //Quando tocar no ch�o, grounded se torna falso
    private void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("GroundTag"))
        {
            grounded = false;
        }

        if (c.collider.CompareTag("Player"))
        {
            tocou_player=false;
        }
    }
    public void Atacar()
    {
        
    }

    public void AtacouAlvo()
    {
        if (tocou_player)
        {
            Debug.Log("Fallen Acertou");
            
        }
    }
    public void Atacando()
    {
        if (tocou_player)
        {

            Debug.Log("AtacandoDenovo");
            animator.SetTrigger("atacar");
        }
        else
        {
            Debug.Log("Andando");
            pode_andar = true;
            animator.SetBool("correr", false);
        }
    }
}
