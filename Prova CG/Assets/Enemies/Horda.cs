using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Horda : MonoBehaviour
{

    //Instancia
    public static Horda instance;

    //Vari�veis da horda
    private float contagem=5;
    public double total_fallen_nesta_horda=0;
    public int total_fallen_vivos;
    private int wave_number = 0;


    //Variaveis do invocador
    private bool activated=false;
    private bool spawning = false;
    private int time_to_next_wave = 5;
    private int time_to_next_enemy = 2;

    //Pegando componente
    public GameObject spawner;
    public GameObject fallen_bot;
    public GameObject player;

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

    //Coletando o objeto do inimigo.
    




    void Start()
    {

    }

    void Update()
    {
        Limitador();
        //horda.Controlador();

    }

    public void Limitador()
    {
        if (activated)
        {
            Controlador();    

        }
    }

    public int getHordaNumero() {return this.wave_number;}

    public void startWaves() { this.activated = true; if (this.wave_number == 0) { this.wave_number = 1; } }

    public void fallenMorto() { this.total_fallen_vivos-=1; }


    public void Controlador()
    {
        //Se o spawner n�o estiver ativo, ele vai executar a contagem regressiva
        if (this.spawning == false && this.total_fallen_vivos<=0)
        {
            this.contagem -= Time.deltaTime;
        }

        //Assim que a contagem regressiva acabar, ele vai come�ar a invocar os inimigos.
        if (this.contagem <= 0)
        {
            this.contagem = this.time_to_next_wave; //Reseta o timer
            this.spawning = true; //Define que o spawner t� ativado 
            StartCoroutine(ConjurarHorda());//Funcao que invoca as criaturas

        }
    }
    private IEnumerator ConjurarHorda()
    {
        var spawn_position = this.spawner.transform;
        //Calculo SpawnInimigos
        this.total_fallen_nesta_horda = 6 + (6 * (this.wave_number -1) * 0.5); //6+ (6 x 0 x 0.5) = 6

        //Enquanto "i" for menor que o numero de inimigos nesta wave, executa o codigo abaixo
        for (int i = 0; i < this.total_fallen_nesta_horda; i++)
        {
            //Pega a posi��o do spawner onde o script se situa
            Vector3 pivotPosition = spawn_position.position;

            //Define posi��o x e z aleat�rias
            float posX = pivotPosition.x + Random.Range(-10, 10);
            float posZ = pivotPosition.z + Random.Range(-10, 10);

            //Instancia um objeto do tipo Fallen
            GameObject newEnemy = Instantiate(this.fallen_bot, new Vector3(posX, pivotPosition.y, posZ), Quaternion.identity);
            newEnemy.transform.SetParent(spawn_position.transform, true);
            var scriptenemy = newEnemy.GetComponent<FallenBotScript>();
            scriptenemy.setTarget(this.player);
            scriptenemy.setHP(getHordaNumero());
            scriptenemy.setHorda(this);

            total_fallen_vivos+=1;
            //Espera alguns segundos antes de continuar o for
            yield return new WaitForSeconds(time_to_next_enemy);

        }
        //Permite que o spawner possa continuar funcionando
        this.wave_number += 1;
        this.spawning = false;
        
    }
}

    


