using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallenScript : MonoBehaviour {
    [SerializeField] private float stoppingDistance = 2f;
    private Animator animator = null;
    private GameObject player;
    private NavMeshAgent navMesh;
    private bool canAttack;
    private Horda horda;
    [SerializeField] public int pontosDeVida = 6;
    public GameObject fallen;

    //Start is called before the first frame update
    void Start() {
        canAttack = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        navMesh.stoppingDistance = stoppingDistance;
        fallen = gameObject;
    }

    public void setTarget(GameObject player) { this.player = player; }
    public void setHP(int horda) { this.pontosDeVida = 8 + 10 * (horda-1); }
    public void setHorda(Horda horda) { this.horda = horda; }

    //Update is called once per frame
    void Update() {
        navMesh.destination = player.transform.position;
        float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToTarget > navMesh.stoppingDistance){
            animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        }

        if(distanceToTarget <= navMesh.stoppingDistance){
            animator.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
            canAttack = true;
            Attack();
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
            player.GetComponent<Damage>().vida -= 10;
        }

    }

    IEnumerator AttackTime() {
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
}
