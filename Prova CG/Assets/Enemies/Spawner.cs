using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Coletando o objeto do inimigo.
    [SerializeField] public GameObject fallenbot;
    public GameObject spawner;
    public Horda horda;


    void Start()
    {
        horda.setComponents(fallenbot,spawner);

    }

    void Update()
    {
        //horda.Limitador();
        horda.Controlador();

    }

   
}
