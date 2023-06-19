using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private bool acertou=false;
    public Controlador controlador;


    private void OnCollisionEnter(Collision c)
    {

        if (c.collider.CompareTag("Player"))
        {
            acertou = true;
            Debug.Log("Acertou");
            //controlador.
        }
    }
}