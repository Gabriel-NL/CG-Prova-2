using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    
    public UI classe_interface_usuario;
    public Horda horda;
    private bool touching;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && touching)
        {
            horda.startWaves();
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
            classe_interface_usuario.AtualizarNomeMensagem("Aperte F para iniciar uma nova horda");
            touching = true;
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
            classe_interface_usuario.AtualizarNomeMensagem("");
            touching = false;
        }
    }
}
