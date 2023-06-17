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

        ParticleSystem particle= impactoVFX.GetComponent<ParticleSystem>();
        var modulo = particle.main;

        cor = modulo.startColor.color;


        if (c.collider.CompareTag("EnemyTag"))
        {
            pd.AcertouTiro(20);

            FallenScript botscript;
            
            if (c.gameObject.GetComponent<FallenScript>() != null)
            {
                botscript = c.gameObject.GetComponent<FallenScript>();
                botscript.RecebendoDano(tipo.Dano);

                audioSource.Play();
                Destroy(soundInstance, audioSource.clip.length);

                var impact = Instantiate(impactoVFX, c.contacts[0].point, Quaternion.identity) as GameObject;

                impact.GetComponent<ParticleSystem>().startColor = cor;

                Destroy(impact, 2);
                Destroy(gameObject);
            }

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