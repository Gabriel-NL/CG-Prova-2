using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilCollider : MonoBehaviour // sistema para colisão de projéteis e o seu impacto
{
    public GameObject impactoVFX;
    public GameObject audioPlayer;
    public PlayerData pd;
    public Estrutura tipo;
   
    
    public void setTipo(Estrutura est) { this.tipo = est; }
    void OnCollisionEnter(Collision co)
    {
        GameObject soundInstance = Instantiate(audioPlayer, transform.position, Quaternion.identity);

        AudioSource audioSource = soundInstance.GetComponent<AudioSource>();


        if (co.gameObject.tag == "EnemyTag")
        {
            pd.AcertouTiro(20);
            FallenScript botscript= co.gameObject.GetComponent<FallenScript>();
            if (botscript != null)
            {
                // Accessing variables inside the script component
                botscript.pontosDeVida-= tipo.Dano;
                Debug.Log("HP: "+botscript.pontosDeVida);
                // Use the variables as needed
            }

            audioSource.Play();
            Destroy(soundInstance, audioSource.clip.length);

            var impact = Instantiate(impactoVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);
            Destroy(gameObject);
        }
        if (co.gameObject.tag == "WallTags" || co.gameObject.tag == "GroundTag")
        {
            audioSource.Play();
            Destroy(soundInstance, audioSource.clip.length);

            var impact = Instantiate (impactoVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy (impact, 2);
            Destroy (gameObject);   
        }
    }

}