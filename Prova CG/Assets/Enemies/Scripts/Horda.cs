using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Horda : MonoBehaviour
{

    //Variaveis da horda
    private float contagem=5;
    public double total_fallen_nesta_horda=0;
    public int total_fallen_vivos;
    private int numero_rodada = 0;


    //Variaveis do invocador
    private bool invocadores_ativados=false;
    private bool invocando = false;
    private readonly int segundos_para_proxima_horda = 5;
    private readonly int segundos_para_proximo_inimigo = 2;

    //Pegando componente
    public GameObject invocador;
    public GameObject fallen_bot;
    public GameObject player;
    public UI classe_interface_usuario;

    void Update()
    {
        Limitador();

    }

    public void Limitador()
    {
        if (invocadores_ativados)
        {
            Controlador();    

        }
    }


    public void IniciarHordas() { this.invocadores_ativados = true; if (this.numero_rodada == 0) { this.numero_rodada = 1; } }

    public void FallenMorto() { this.total_fallen_vivos-=1; }


    public void Controlador()
    {
        //Se o invocador n�o estiver ativo, ele vai executar a contagem regressiva
        if (this.invocando == false && this.total_fallen_vivos<=0)
        {
            classe_interface_usuario.AtualizarNumeroHorda(this.numero_rodada);
            this.contagem -= Time.deltaTime;

        }

        //Assim que a contagem regressiva acabar, ele vai comecar a invocar os inimigos.
        if (this.contagem <= 0)
        {
            this.contagem = this.segundos_para_proxima_horda;
            this.invocando = true;  
            StartCoroutine(ConjurarHorda());

        }
    }
    private IEnumerator ConjurarHorda()
    {
        var posicao_invocacao = this.invocador.transform;
        //Calculo SpawnInimigos
        this.total_fallen_nesta_horda = 6 + (6 * (this.numero_rodada -1) * 0.5); //6+ (6 x 0 x 0.5) = 6

        //Enquanto "i" for menor que o numero de inimigos nesta wave, executa o codigo abaixo
        for (int i = 0; i < this.total_fallen_nesta_horda; i++)
        {
            //Pega a posi��o do invocador onde o script se situa
            Vector3 pivotPosition = posicao_invocacao.position;

            //Define posi��o x e z aleat�rias
            float posX = pivotPosition.x + Random.Range(-10, 10);
            float posZ = pivotPosition.z + Random.Range(-10, 10);

            //Instancia um objeto do tipo Fallen
            GameObject newEnemy = Instantiate(this.fallen_bot, new Vector3(posX, pivotPosition.y, posZ), Quaternion.identity);
            newEnemy.transform.SetParent(posicao_invocacao.transform, true);
            var scriptenemy = newEnemy.GetComponent<FallenScript>();
            scriptenemy.setTarget(this.player);
            scriptenemy.setHP(this.numero_rodada);
            scriptenemy.setHorda(this);

            total_fallen_vivos+=1;
            //Espera alguns segundos antes de continuar o for
            yield return new WaitForSeconds(segundos_para_proximo_inimigo);

        }
        //Permite que o invocador possa continuar funcionando
        this.numero_rodada += 1;
        this.invocando = false;
        
    }
}

    


