using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controlador : MonoBehaviour
{
    /*---------------------------------------------*/
    //Pegando instancias
    private VerCargas classe_ver_cargas = VerCargas.Instance;
    private Vida_morte classe_vida_morte = Vida_morte.Instance;
    private Movimento classe_movimento = Movimento.Instance;

    /*---------------------------------------------*/
    //Pegando objetos
    public TMP_Text objetoMunicao;
    public GameObject imagemDano;
    public GameObject player;
    public PlayerData pd;

    /*---------------------------------------------*/

    //Função que ocorre toda vez que o jogo é iniciado
    void Start()
    {
        
        classe_vida_morte.setObject(imagemDano);
        classe_movimento.setObject(player);
        classe_movimento.Debugando();
    }

    //Função que ocorre á cada segundo
    void FixedUpdate()
    {
        if (classe_vida_morte.PlayerVivo())
        {
            classe_movimento.PlayerMovementSystem();
            classe_ver_cargas.PlayerAmmoSystem(objetoMunicao,pd);

        }
    }

    private void OnCollisionEnter(Collision c)
    {

        //Se jogador tocar no chão, esta condinção é ativada
        if (c.gameObject.tag == "GroundTag")
        {
            classe_movimento.setGrounded(true);

        }

        if (c.gameObject.tag == "EnemyTag")
        {
            StartCoroutine(classe_vida_morte.IntervaloParatestes());

        }
    }

    private void OnCollisionExit(Collision c)
    {

        //Se o jogador pular, ou sair do chão de alguma forma, esta condinção é ativada
        if (c.gameObject.tag == "GroundTag")
        {
            classe_movimento.setGrounded(false);

        }

        if (c.gameObject.tag == "EnemyTag")
        {

        }
    }
}
