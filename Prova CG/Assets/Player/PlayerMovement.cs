using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 10;
    public float velocidade_de_corrida=50;
    public KeyCode tecla_de_corrida= KeyCode.LeftShift;
    public Animator anim;

    public Rigidbody rb;
    public float velocidade_atual;




    // Start is called before the first frame update
    void Start()
    {
 
        velocidade_atual=velocidade;
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
