using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Player
{


public class Controlador : MonoBehaviour
{
    /*---------------------------------------------*/
    //Pegando instancias
    private UI classe_user_interface = UI.Instance;
    private Vida_morte classe_vida_morte = Vida_morte.Instance;
    private Movimento classe_movimento = Movimento.Instance;

    /*---------------------------------------------*/
    //Pegando objetos
    public TMP_Text objetoMunicao;
    public TMP_Text objetoPontos;
    public TMP_Text objetoHorda;

    public GameObject imagemDano;
    public GameObject player;
    public PlayerData pd;
    public Horda horda;
    public AudioSource audioPlayer;

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
        if (pd.playerState())
        {
            classe_movimento.PlayerMovementSystem();
            classe_user_interface.PlayerAmmoSystem(objetoMunicao,pd);
            classe_user_interface.PointSystem(objetoPontos, pd);
            classe_user_interface.RoundSystem(objetoHorda, horda);
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

        public void Ativado()
        {
            //audioPlayer.Play();
        }


    }

}