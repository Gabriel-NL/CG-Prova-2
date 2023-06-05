using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    //Instancia
    public static Movimento instance;
    
    //Teclas
    private KeyCode tecla_de_corrida = KeyCode.LeftShift;

    //Componentes
    public GameObject player;
    private Rigidbody playerRB;
    private Animator playerANIM;
    private Transform playerTRANS;

    //Variaveis 
    private float velocidade = 10;
    private float velocidade_de_corrida = 10;
    private float velocidade_atual;

    //Variaveis pro pulo
    private bool grounded = false;
    private int jumpforce = 700;
    private int gravityForce = 50;

    public static Movimento Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Movimento();
            }
            return instance;
        }
    }


    public void setGrounded(bool grounded)
    {
        this.grounded = grounded;
    }

    void Start()
    {
        this.playerRB = this.player.GetComponent<Rigidbody>();
        this.playerANIM = this.player.GetComponent<Animator>();
        this.playerTRANS = this.player.transform;
    }


    //Funcao que gerencia sistema de movimento
    public void PlayerMovementSystem()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            this.playerRB.AddForce(Vector3.up * jumpforce);
        }

        if (inputX != 0 || inputZ != 0)
        {
            //this.playerANIM.SetBool("moving", true);
            this.playerTRANS.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidade_atual, Space.Self);
            

            if (Input.GetKeyDown(tecla_de_corrida))
            {
                //anim.SetBool("running", true);
                velocidade_atual = velocidade_de_corrida;
            }
            else
            {
                //anim.SetBool("running", false);
                velocidade_atual = velocidade;
            }
        }
        else
        {
            //anim.SetBool("moving", false);
            //anim.SetBool("running", false);
            velocidade_atual = velocidade;
        }

        this.playerRB.AddForce(Vector3.down * gravityForce);

    }
}
