using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallenScript : MonoBehaviour {

    //Variaveis
    private int pontosDeVida = 6;
    public float stoppingDistance = 5f;
    private bool canAttack;
    public bool grounded = false;

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
        canAttack = true;
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


        navMesh.destination = player.transform.position;
        float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distanceToTarget.ToString());

        if(distanceToTarget > navMesh.stoppingDistance){
            //animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
            animator.SetBool("correr", true);
            navMesh.isStopped = false;
        }

        if(distanceToTarget <= navMesh.stoppingDistance){
            //animator.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
            animator.SetTrigger("atacar");
            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;
            canAttack = true;
            Attack();
            //animator.SetBool("correr", false);
        }

        if (fallen.transform.position.y < -10 || this.pontosDeVida<=0)
        {
            if (this.horda != null){this.horda.FallenMorto();}
            
            Destroy(fallen);
        }


    }

    void Attack() {
        if(canAttack == true) {
            StartCoroutine("AttackTime");
            //player.GetComponent<Damage>().vida -= 10;
        }

    }

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

    IEnumerator AttackTime() {
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
}
