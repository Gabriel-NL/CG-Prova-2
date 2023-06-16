using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargaDeCargas : MonoBehaviour
{
    public UI classe_interface_usuario;
    public PlayerData playerData;
    private bool touching;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && touching)
        {
            playerData.RecarregarCargas();
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            classe_interface_usuario.AtualizarNomeMensagem("Aperte F para recarregar");
            
            touching = true;
        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            classe_interface_usuario.AtualizarNomeMensagem("");
            touching = false;
        }
    }
}
