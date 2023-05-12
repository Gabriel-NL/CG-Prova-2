using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidade_de_corrida=10;
    public KeyCode tecla_de_corrida= KeyCode.LeftShift;
    //public Animator anim;

    private Rigidbody rb;
    public float velocidade_atual;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidade_atual=velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (inputX != 0 || inputZ != 0) 
        {
            transform.Translate(new Vector3(inputX, 0, inputZ) * Time.deltaTime * velocidade_atual, Space.Self);

            if (Input.GetKey(tecla_de_corrida))
            {
                //anim.SetBool("run", true);
                velocidade_atual = velocidade_de_corrida;
            }
            else
            {
                //anim.SetBool("run", false);
                velocidade_atual = velocidade;
            }
        }
        else
        {
            //anim.SetBool("run", false);
            velocidade_atual = velocidade;
        }
  


    }
}
