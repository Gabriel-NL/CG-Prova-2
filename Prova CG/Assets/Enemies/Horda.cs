using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{

    //Instancia
    public static Horda instance;

    //Variáveis da horda
    private float contagem=3;
    private double inimigos_nesta_wave;
    private int inimigos_invocados;
    private bool spawning = false;
    private int wave_number = 0;
    private int time_to_next_wave = 10;
    private int time_to_next_enemy = 2;

    //Pegando componente
    private GameObject fallen_bot;
    private Transform spawn_position;

    //Aplicando Singleton
    public static Horda Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Horda();
            }
            return instance;
        }
    }

    public void Limitador()
    {
        if (this.wave_number > 0)
        {
            this.wave_number = 1;
            Controlador();    

        }
    }

    public int getHordaNumero()
    {
        return this.wave_number;
    }

    public void setComponents(GameObject bot, GameObject position)
    {
        this.fallen_bot = bot;
        this.spawn_position = position.transform;

    }


    public void Controlador()
    {
        //Se o spawner não estiver ativo, ele vai executar a contagem regressiva
        if (this.spawning == false)
        {
            this.contagem -= Time.deltaTime;
        }

        //Assim que a contagem regressiva acabar, ele vai começar a invocar os inimigos.
        if (this.contagem <= 0)
        {
            this.contagem = this.time_to_next_wave; //Reseta o timer
            this.spawning = true; //Define que o spawner tá ativado 
            StartCoroutine(ConjurarHorda());//Funcao que invoca as criaturas

        }
    }
    private IEnumerator ConjurarHorda()
    {
        //Calculo SpawnInimigos
        this.inimigos_nesta_wave = 6 + (6 * (this.wave_number -1) * 0.5); //6+ (6 x 0 x 0.5) = 6

        //Enquanto "i" for menor que o numero de inimigos nesta wave, executa o codigo abaixo
        for (int i = 0; i < this.inimigos_nesta_wave; i++)
        {
            //Pega a posição do spawner onde o script se situa
            Vector3 pivotPosition = spawn_position.position;

            //Define posição x e z aleatórias
            float posX = pivotPosition.x + Random.Range(-10, 10);
            float posZ = pivotPosition.z + Random.Range(-10, 10);

            //Instancia um objeto do tipo Fallen
            GameObject newEnemy = Instantiate(this.fallen_bot, new Vector3(posX, pivotPosition.y, posZ), Quaternion.identity);
            inimigos_invocados++;
            //Espera alguns segundos antes de continuar o for
            yield return new WaitForSeconds(time_to_next_enemy);

        }
        //Permite que o spawner possa continuar funcionando
        spawning = false;
        wave_number++;
    }
}

    


