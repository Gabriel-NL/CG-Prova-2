using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peanut : MonoBehaviour
{
    public Controlador controlador;
    public PlayerData playerData;
    private bool touching;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && touching)
        {
            playerData.recarregarCargas();
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            ;
            controlador.classe_user_interface.mensagem = "Aperte F para recarregar";
            
            touching = true;
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            controlador.classe_user_interface.mensagem = "";
            touching = false;
        }
    }
}
