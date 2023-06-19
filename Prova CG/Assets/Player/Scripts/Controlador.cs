using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        public PlayerData pd;
        /*---------------------------------------------*/

        private readonly KeyCode tecla_de_ferimento = KeyCode.Tab;
        /*---------------------------------------------*/

        void Start()
        {
            pd.Inicializar();
            Cursor.lockState = CursorLockMode.Locked;
           
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

            //Se ele estiver vivo, executa estas fun��es, sen�o, roda anima��o de morte
            if (pd.JogadorVivo())
            {
                AtivarFuncoes();   
            }
            else
            {   
                var cam_animator=camera_objeto.GetComponent<Animator>();
                cam_animator.SetBool("dead", true);

                Invoke("RetonarTelaInicial", 3f);
            }


        }

        void RetonarTelaInicial()
        {
            SceneManager.LoadScene("TelaInicial");
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
        public void AtivarFuncoes()
        {
            classe_movimento.SistemaDeCorrida();
            pd.SistemaDeTrocaDeMagias();
            classe_visao.CameraSystem(jogador_objeto.transform, camera_objeto.transform);
            classe_disparo.CastingSystem();
        }

    }
}