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
        private Visao classe_visao = Visao.Instance;
        private Disparo classe_disparo = Disparo.Instance;
        public TodasAsMagias todas_as_magias;

        /*---------------------------------------------*/
        //Pegando objetos
        public Movimento classe_movimento;
        public UI classe_user_interface;
        public GameObject player;
        public GameObject camera;
        public GameObject firepoint;
        public Animator playerAnimator;
        public Animator cameraAnimator;
        public PlayerData pd;
        public Horda horda;

        /*---------------------------------------------*/

        private Camera cam;
        private KeyCode tecla_de_ferimento = KeyCode.Tab;
        /*---------------------------------------------*/

        //Função que ocorre toda vez que o jogo é iniciado
        void Start()
        {
            pd.initialize();
            Cursor.lockState = CursorLockMode.Locked;
            cam = camera.GetComponent<Camera>();

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
                pd.SwitchSpells();
                classe_user_interface.UIHandler(pd,horda);
                classe_visao.CameraSystem(player.transform, camera.transform);
                classe_disparo.CastingSystem(cam, firepoint.transform, pd);
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