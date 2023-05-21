using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    
    //Keys
    public KeyCode tecla_de_corrida = KeyCode.LeftShift;

    // Variables for movement System
    public float velocidade = 10;
    public float velocidade_de_corrida = 50;
    public float velocidade_atual;


    //Components for movement System
    public Animator anim;
    public Rigidbody rb;

    //Function that handles movement System
    public void PlayerMovementSystem()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 50); ;
        }

        if (inputX != 0 || inputZ != 0)
        {
            anim.SetBool("moving", true);
            transform.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidade_atual, Space.Self);

            if (Input.GetKeyDown(tecla_de_corrida))
            {
                anim.SetBool("running", true);
                velocidade_atual = velocidade_de_corrida;
            }
            else
            {
                anim.SetBool("running", false);
                velocidade_atual = velocidade;
            }
        }
        else
        {
            anim.SetBool("moving", false);
            anim.SetBool("running", false);
            velocidade_atual = velocidade;
        }

    }
    //Variables for movement System
    public Transform player_transform;
    private float sensibilidade = 5;
    private float suavizacao = 1.5f;
    private Vector2 velocidade_frame, velocidade_rotacao;


}
