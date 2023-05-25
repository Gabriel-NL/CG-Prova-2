using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    //Instancia
    public static Movimento instance;

    //Componentes
    private GameObject player;
    private Rigidbody playerRB;
    private Animator playerANIM;
    private Transform playerTRANS;

    //Teclas
    private KeyCode tecla_de_corrida = KeyCode.LeftShift;

    //Variaveis 
    private float velocidade = 10;
    private float velocidade_de_corrida = 50;
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
    
    public void setObject(GameObject gm)
    {
        this.player = gm; 
        playerRB = player.GetComponent<Rigidbody>();
        playerANIM = player.GetComponent<Animator>();
        playerTRANS = player.transform;
    }

    // Start is called before the first frame update
    public void Debugando()
    {
        if (player != null)
        {
            Debug.Log("Player existe");
        }
        else
        {
            Debug.Log("Player nao existe");
        }
    }

    //Funcao que gerencia sistema de movimento
    public void PlayerMovementSystem()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            playerRB.AddForce(Vector3.up * jumpforce);
        }

        if (inputX != 0 || inputZ != 0)
        {
            playerANIM.SetBool("moving", true);
            playerTRANS.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidade_atual, Space.Self);

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

        playerRB.AddForce(Vector3.down * gravityForce);

    }
}
