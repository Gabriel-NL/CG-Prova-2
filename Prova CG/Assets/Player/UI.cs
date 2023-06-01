using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    //Componentes
    public TMP_Text objetoMunicao;
    public TMP_Text objetoPontos;
    public TMP_Text objetoHorda;
    public TMP_Text objetoNome;
    public TMP_Text objetoInteracao;
    public Image ferimento;

    //Variaveis
    private bool atirando = false;
    public string mensagem;

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
    public void UIHandler(PlayerData pd,Horda horda)
    {
        objetoMunicao.text = "Cargas: " + pd.getCargas();
        objetoPontos.text = pd.getPontosDevocao().ToString();
        objetoHorda.text = horda.getHordaNumero().ToString();
        objetoNome.text = pd.getCurrentSpellData().Nome;
        objetoInteracao.text = mensagem;
        HealthSystem(pd);
    }
    //Funcao que gerencia sistema de municao

    private void HealthSystem(PlayerData pd)
    {

        
        if (pd.getHP()==3)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0;
            ferimento.color = tempColor;
        }

        if (pd.getHP() == 2)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.2f;
            ferimento.color = tempColor;
        }
        if (pd.getHP() == 1)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.5f;
            ferimento.color = tempColor;
        }

        if (pd.getHP() == 0)
        {
            var tempColor = ferimento.color;
            tempColor.a = 1f;
            ferimento.color = tempColor;
        }

    }

}
