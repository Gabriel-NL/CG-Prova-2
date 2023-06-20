using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour // sistema para colisão de projéteis e o seu impacto
{
    public GameObject impactoVFX;
    public GameObject audioPlayer;
    private PlayerData pd;
    private Estrutura tipo;
    private Color cor;
   
    
    public void InicializandoValores(Estrutura est, PlayerData pd) {
        this.tipo = est; 
        this.pd = pd;
    
    }
    void OnCollisionEnter(Collision c)
    {
        GameObject soundInstance = Instantiate(audioPlayer, transform.position, Quaternion.identity);
        AudioSource audioSource = soundInstance.GetComponent<AudioSource>();

        if (c.collider.CompareTag("EnemyTag"))
        {
            pd.AdicionarPontosDevocao(20);
            

            
            if (c.gameObject.GetComponent<FallenScript>() != null)
            {
            FallenScript botscript;
                botscript = c.gameObject.GetComponent<FallenScript>();

                if (c.collider.name == "mixamorig5:Head")
                {
                    botscript.RecebendoDano(tipo.Dano*3);
                }
                else
                {
                    botscript.RecebendoDano(tipo.Dano);
                }
            }
            audioSource.Play();
                Destroy(soundInstance, audioSource.clip.length);

                var impact = Instantiate(impactoVFX, c.contacts[0].point, Quaternion.identity) as GameObject;

                Destroy(impact, 2);
                Destroy(gameObject);



        }
        if (!c.collider.CompareTag("Player") && !c.collider.CompareTag("Spell"))
        {
            audioSource.Play();
            Destroy(soundInstance, audioSource.clip.length);

            var impact = Instantiate (impactoVFX, c.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy (impact, 2);
            Destroy (gameObject);   
        }
    }

}