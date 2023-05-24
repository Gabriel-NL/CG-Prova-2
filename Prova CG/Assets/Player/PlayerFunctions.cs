using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFunctions : MonoBehaviour
{
    //Teclas
    public KeyCode tecla_de_corrida = KeyCode.LeftShift;

    //Variaveis para sistema de movimento
    public float velocidade = 10;
    public float velocidade_de_corrida = 50;
    public float velocidade_atual;

    //Componentes para sistema de movimento
    //public Animator anim;
    public Rigidbody rb;

    /*---------------------------------------------*/

    //Variaveis para sistema de municao
    public bool atirando = false;

    //Componentes para sistema de municao
    public PlayerData pd= PlayerData.Instance;
    public TMP_Text mostrarMunicao;


    /*---------------------------------------------*/
    //Variaveis para sistema de pulo
    public bool grounded = false;
    public int jumpforce;
    public int gravityForce;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        PlayerMovementSystem();
        PlayerAmmoSystem();
    }

    private void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag=="GroundTag")
        {
            grounded = true;
            
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "GroundTag")
        {
            grounded = false;

        }
    }


    //Funcao que gerencia sistema de movimento
    public void PlayerMovementSystem()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpforce); 
        }

        if (inputX != 0 || inputZ != 0)
        {
            //anim.SetBool("moving", true);
            transform.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidade_atual, Space.Self);

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

        rb.AddForce(Vector3.down * gravityForce);

    }

    //Funcao que gerencia sistema de municao
    public void PlayerAmmoSystem()
    {
        mostrarMunicao.text = "Cargas: " + pd.getCargas().ToString();
        if (Input.GetMouseButtonDown(0) && !atirando && pd.getCargas() > 0)
        {
            atirando = true;
            
            atirando = false;
        }
    }
}

