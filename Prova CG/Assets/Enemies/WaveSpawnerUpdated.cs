using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerUpdated : MonoBehaviour
{
    //Coletando o objeto do inimigo.
    [SerializeField] public GameObject fallenbot;

    //Estas variaveis ser�o exibidas para ser mais facil de visualizar o funcionamento
    public float contagem;
    public int wave_number = 1;
    public double inimigosNestaWave;
    public int inimigosInvocados;
    public bool spawning = false;

    //Estas aqui vou esconder
    private int timeToNextWave=20;
    private int timeToNextEnemy=2;
    



    private void Update()
    {
        //Se o numero da Wave for maior que 0, ent�o entrariamos no round 1
        if (wave_number>0)
        {
            //Se o spawner n�o estiver ativo, ele vai executar a contagem regressiva
            if (spawning == false)
            {
                contagem -= Time.deltaTime;
            }

            //Assim que a contagem regressiva acabar, ele vai come�ar a invocar os inimigos.
            if (contagem <= 0)
            {
                contagem = timeToNextWave; //Reseta o timer
                spawning = true; //Define que o spawner t� ativado 
                StartCoroutine(SpawnWaveUpdated());//Funcao que invoca as criaturas

            }
        }
        
    }

    private IEnumerator SpawnWaveUpdated()
    {
        //Calculo SpawnInimigos
        inimigosNestaWave=2 *(wave_number*1.5);

        //Enquanto "i" for menor que o numero de inimigos nesta wave, executa o codigo abaixo
        for (int i = 0; i < inimigosNestaWave; i++) 
        {
            //Pega a posi��o do spawner onde o script se situa
            Vector3 pivotPosition = transform.position;

            //Define posi��o x e z aleat�rias
            float posX = pivotPosition.x + Random.Range(-10, 10);
            float posZ = pivotPosition.z + Random.Range(-10, 10);

            //Instancia um objeto do tipo Fallen
            GameObject newEnemy = Instantiate(fallenbot, new Vector3(posX, pivotPosition.y, posZ), Quaternion.identity);
            inimigosInvocados++;
            //Espera alguns segundos antes de continuar o for
            yield return new WaitForSeconds(timeToNextEnemy);

        }
        //Permite que o spawner possa continuar funcionando
        spawning = false;
        wave_number++;
    }
}
