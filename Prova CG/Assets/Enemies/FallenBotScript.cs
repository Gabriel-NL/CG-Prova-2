using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenBotScript : MonoBehaviour
{

    //Componentes
    [SerializeField] public GameObject player;
    public Rigidbody rb;
    public GameObject fallen;
    private Horda horda;
    
    //Variaveis
    [SerializeField] public int pontosDeVida=6;
    public float speed = 3.5f;
    public bool grounded=false;



    //Quando tocar no ch�o, grounded se torna verdadeiro
    private void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "GroundTag")
        {
            grounded = true;

        }
        if (c.gameObject.tag == "Spell")
        {

           


            //Destroy(fallen);
        };
    }

    //Quando tocar no ch�o, grounded se torna falso
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "GroundTag")
        {
            grounded = false;
        }
    }
    
    public void setTarget(GameObject player) { this.player = player; }
    public void setHP(int horda) { this.pontosDeVida = 8 + 10 * (horda-1); }

    public void setHorda(Horda horda) { this.horda = horda; }
    void Update()
    {
        //Aviso: Por algum motivo,
        //Toda vez que a gravidade e aplicada no rigid body
        //O root motion para de funcionar
        //Entao criei um codigo que faz a gravidade ser aplicada
        //Somente quando ele nao tocar no ch�o
        transform.LookAt(player.gameObject.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (grounded==false)
        {
            rb.AddForce(Vector3.down * 30);
            
        }
        if (fallen.transform.position.y < -10 || this.pontosDeVida<=0)
        {
            if (this.horda != null){this.horda.fallenMorto();}

            Destroy(fallen);
        }

    }




}
