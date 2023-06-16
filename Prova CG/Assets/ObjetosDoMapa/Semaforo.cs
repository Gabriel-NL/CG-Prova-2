using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    
    public Controlador controlador;
    public Horda horda;
    private bool touching;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                controlador.classe_interface_usuario.mensagem="Aperte F para iniciar uma nova horda";
                touching = true;
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
            controlador.classe_interface_usuario.mensagem = "";
            touching = false;
        }
    }
}
