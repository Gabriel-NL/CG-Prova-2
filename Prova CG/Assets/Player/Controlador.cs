using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Player
{


    public class Controlador : MonoBehaviour
    {
        /*---------------------------------------------*/
        //Pegando scripts
        public Visao classe_visao;
        public Movimento classe_movimento;
        public Disparo classe_disparo;
        public TodasAsMagias todas_as_magias;
        /*---------------------------------------------*/
        //Pegando objetos
        public GameObject jogador_objeto;
        public GameObject camera_objeto;
        public GameObject ponto_de_disparo;
        //public Animator player_CA;
        public Animator camera_CA;
        public PlayerData pd;
        public Horda horda;
        /*---------------------------------------------*/
        private Camera camera_componente;
        private readonly KeyCode tecla_de_ferimento = KeyCode.Tab;
        /*---------------------------------------------*/

        void Start()
        {
            pd.Inicializar();
            Cursor.lockState = CursorLockMode.Locked;
            camera_componente = camera_objeto.GetComponent<Camera>();

            //classe_disparo.animatorPlayer = player_CA;
        }

        void FixedUpdate()
        {
            if (pd.JogadorVivo())
            {
                classe_movimento.SistemaDeMovimentoDoJogador();
            }
        }

        void Update()
        {
            if (pd.JogadorVivo())
            {
                classe_movimento.SistemaDeCorrida();
                pd.SistemaDeTrocaDeMagias();
                classe_visao.CameraSystem(jogador_objeto.transform, camera_objeto.transform);
                classe_disparo.CastingSystem(camera_componente, ponto_de_disparo.transform, pd);

                if (Input.GetKeyDown(tecla_de_ferimento))
                {
                    pd.TomouDano();
                }
            }
            else
            {
                camera_CA.SetBool("dead", true);
            }
        }

        private void OnCollisionEnter(Collision c)
        {
            //Se jogador tocar no chao, esta condincao e ativada
           
            if (c.collider.CompareTag("GroundTag"))
            {
                classe_movimento.SetGrounded(true);
            }
            if (c.collider.CompareTag("WallTags"))
            {
                classe_movimento.isRunning=false;
            }
        }

        private void OnCollisionExit(Collision c)
        {
            //Se o jogador pular, ou sair do chao de alguma forma, esta condincao e ativada
            if (c.collider.CompareTag("GroundTag")) {
                classe_movimento.SetGrounded(false);
            }
        }

    }
}