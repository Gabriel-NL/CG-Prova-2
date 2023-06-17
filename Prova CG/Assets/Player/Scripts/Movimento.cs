using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    //Instancia
    public static Movimento instance;
    
    //Teclas
    private readonly KeyCode tecla_de_corrida = KeyCode.LeftShift;

    //Componentes
    public GameObject jogador;
    private Rigidbody jogador_rigidBody;
    //private Animator jogador_controle_animacoes;
    private Transform jogador_transform;

    //Variaveis movimento
    private readonly float velocidade_caminhada = 10;
    private readonly float velocidade_corrida = 20;
    public bool isRunning;

    //Variaveis pulo
    private bool grounded = false;
    private readonly int jumpforce = 700;
    private readonly int gravityForce = 50;




    public void SetGrounded(bool grounded)
    {
        this.grounded = grounded;
    }

    void Start()
    {
        this.jogador_rigidBody = this.jogador.GetComponent<Rigidbody>();
        //this.jogador_controle_animacoes = this.jogador.GetComponent<Animator>();
        this.jogador_transform = this.jogador.transform;
    }


    //Funcao que gerencia sistema de movimento
    public void SistemaDeMovimentoDoJogador()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            this.jogador_rigidBody.AddForce(Vector3.up * jumpforce);
        }

        if (inputX != 0 || inputZ != 0)
        {
            //this.jogador_controle_animacoes.SetBool("moving", true);
            if (isRunning)
            {
                this.jogador_transform.Translate(this.velocidade_corrida * Time.deltaTime * new Vector3(inputX, 0, inputZ), Space.Self);
            }
            else
            {
                this.jogador_transform.Translate(this.velocidade_caminhada * Time.deltaTime * new Vector3(inputX, 0, inputZ), Space.Self);
            }


        }
        else
        {
            //anim.SetBool("moving", false);
            //anim.SetBool("running", false);
            isRunning = false;
        }

        this.jogador_rigidBody.AddForce(Vector3.down * gravityForce);

    }

    public void SistemaDeCorrida()
    {
        if (Input.GetKeyDown(tecla_de_corrida))
        {
            //anim.SetBool("running", true);
            isRunning   = true;
        }
        
        if(Input.GetKeyUp(tecla_de_corrida)) 
        {
            //anim.SetBool("running", false);
            isRunning= false;
        }

    }

}
