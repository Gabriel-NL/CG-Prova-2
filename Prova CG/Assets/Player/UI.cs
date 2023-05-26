using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    //Instancia
    public static UI instance;

    //Variaveis
    private bool atirando = false;
    private int municao;
    private int pontos;
    private int horda;

    public static UI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UI();
            }
            return instance;
        }
    }

    //Funcao que gerencia sistema de municao
    public void PlayerAmmoSystem(TMP_Text mostrarMunicao,PlayerData pd)
    {
        this.municao = pd.getCargas();
        mostrarMunicao.text = "Cargas: " + this.municao;
        if (Input.GetMouseButtonDown(0) && !this.atirando && pd.getCargas() > 0)
        {
            this.atirando = true;
            this.atirando = false;
        }
    }

    public void PointSystem(TMP_Text mostrarPontos,PlayerData pd)
    {
        this.pontos=pd.getPontosDevocao();
        mostrarPontos.text = this.pontos.ToString();

    }

    public void RoundSystem(TMP_Text mostrarHorda, Horda horda)
    {
        this.horda = horda.getHordaNumero();
        mostrarHorda.text = this.horda.ToString();

    }

}
