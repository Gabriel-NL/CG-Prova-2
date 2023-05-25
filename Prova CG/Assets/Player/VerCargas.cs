using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerCargas : MonoBehaviour
{
    //Instancia
    public static VerCargas instance;

    //Variaveis
    private bool atirando = false;
    private int municao;

    public static VerCargas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new VerCargas();
            }
            return instance;
        }
    }

    //Funcao que gerencia sistema de municao
    public void PlayerAmmoSystem(TMP_Text mostrarMunicao,PlayerData pd)
    {
        municao = pd.getCargas();
        Debug.Log(municao);
        mostrarMunicao.text = "Cargas: " + municao;
        Debug.Log(mostrarMunicao.text);
        if (Input.GetMouseButtonDown(0) && !atirando && pd.getCargas() > 0)
        {
            atirando = true;
            atirando = false;
        }
    }
}
