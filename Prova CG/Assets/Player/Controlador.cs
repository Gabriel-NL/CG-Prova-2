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
    private Movimento classe_movimento = Movimento.Instance;
    private Visao classe_visao = Visao.Instance;


    /*---------------------------------------------*/
    //Pegando objetos
    public TMP_Text objetoMunicao;
    public TMP_Text objetoPontos;
    public TMP_Text objetoHorda;
    
    public GameObject player;
    public GameObject camera;
    public GameObject ferimento;

    public Animator cameraAnimator;

    public PlayerData pd;
    public Horda horda;

    /*---------------------------------------------*/

        private KeyCode tecla_de_ferimento = KeyCode.Tab;
        private bool dying = false;
    /*---------------------------------------------*/




    //Função que ocorre toda vez que o jogo é iniciado
    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;
    }

    //Função que ocorre á cada segundo
    void FixedUpdate()
    {
        classe_user_interface.HealthSystem(ferimento, pd);
        if (pd.playerState())
        {
            classe_movimento.PlayerMovementSystem(player);
            classe_user_interface.PlayerAmmoSystem(objetoMunicao,pd);
            classe_user_interface.PointSystem(objetoPontos, pd);
            classe_user_interface.RoundSystem(objetoHorda, horda);
        }


    }

    void Update()
    {
            
            if (pd.playerState())
            {
                classe_visao.CameraSystem(player.transform,camera.transform);
                if (Input.GetKeyUp(tecla_de_ferimento))
                {
                    pd.tomouDano();
                }

            }
            else
            {
                    cameraAnimator.SetBool("dead",true);
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

}