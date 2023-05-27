using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    //Variaveis
    private bool atirando = false;
    private int municao;
    private int pontos;
    private int horda;

    //Instancia
    public static UI instance;

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
    public void HealthSystem(GameObject ferimento, PlayerData pd)
    {
        var image = ferimento.GetComponent<Image>();
        
        if (pd.getHP()==3)
        {
            var tempColor = image.color;
            tempColor.a = 0;
            image.color = tempColor;
        }

        if (pd.getHP() == 2)
        {
            var tempColor = image.color;
            tempColor.a = 0.2f;
            image.color = tempColor;
        }
        if (pd.getHP() == 1)
        {
            var tempColor = image.color;
            tempColor.a = 0.5f;
            image.color = tempColor;
        }

        if (pd.getHP() == 0)
        {
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }

    }


}
