using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilcollider : MonoBehaviour // sistema para colisão de projéteis e o seu impacto
{
    public GameObject impactoVFX;
    public AudioSource audioPlayer;
    public PlayerData pd= PlayerData.Instance;

   

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "EnemyTag")
        {
            pd.acertouTiro(20);
            audioPlayer.Play();

            var impact = Instantiate(impactoVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);
            Destroy(gameObject);
        }
        if (co.gameObject.tag == "WallTags" || co.gameObject.tag == "GroundTag")
        {
            audioPlayer.Play();

            var impact = Instantiate (impactoVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy (impact, 2);
            Destroy (gameObject);   
        }
    }

}