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
        public UI classe_user_interface;
        public Movimento classe_movimento;
        private Visao classe_visao = Visao.Instance;
        private Disparo classe_disparo = Disparo.Instance;
        private TodasAsMagias todas_as_magias = TodasAsMagias.Instance;

        /*---------------------------------------------*/
        //Pegando objetos
        public GameObject player;
        public GameObject camera;
        public GameObject firepoint;
        public GameObject projetil;//Provisorio
        public Animator playerAnimator;
        public Animator cameraAnimator;
        public PlayerData pd;
        public Horda horda;
        public TodasAsMagias spellList;

        /*---------------------------------------------*/

        private Camera cam;
        private KeyCode tecla_de_ferimento = KeyCode.Tab;
        private bool dying = false;
        /*---------------------------------------------*/

        //Função que ocorre toda vez que o jogo é iniciado
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            cam = camera.GetComponent<Camera>();
            pd.EquipamentoInicial(todas_as_magias.getMagia(0));
            pd.EquipamentoInicial(todas_as_magias.getMagia(1));
            classe_disparo.animatorPlayer = playerAnimator;
        }

        //Função que ocorre á cada segundo
        void FixedUpdate()
        {
            if (pd.playerState())
            {
                classe_movimento.PlayerMovementSystem();
            }


        }

        void Update()
        {

            if (pd.playerState())
            {
                classe_user_interface.UIHandler(pd,horda);
                classe_visao.CameraSystem(player.transform, camera.transform);
                classe_disparo.CastingSystem(cam, projetil, firepoint.transform, pd);
                classe_disparo.ChangeSpells(pd);
                if (Input.GetKeyDown(tecla_de_ferimento))
                {
                    pd.tomouDano();
                }

            }
            else
            {
                cameraAnimator.SetBool("dead", true);
            }





        }

        private void OnCollisionEnter(Collision c)
        {

            //Se jogador tocar no chão, esta condinção é ativada
            if (c.gameObject.tag == "GroundTag")
            {
                classe_movimento.setGrounded(true);

            }

        }

        private void OnCollisionExit(Collision c)
        {

            //Se o jogador pular, ou sair do chão de alguma forma, esta condinção é ativada
            if (c.gameObject.tag == "GroundTag")
            {
                classe_movimento.setGrounded(false);

            }

        }


    }

}