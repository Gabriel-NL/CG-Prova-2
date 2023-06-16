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

    //Scripts
    public PlayerData pd;
    public Horda horda;

    //Variaveis
    public string mensagem;

    public void AtualizarUI()
    {
        objetoMunicao.text = "Cargas: " + pd.GetCargas();
        objetoPontos.text = pd.GetPontosDevocao().ToString();
        objetoHorda.text = horda.getHordaNumero().ToString();
        objetoNome.text = pd.GetCurrentSpellData().Nome;
        objetoInteracao.text = mensagem;
        HealthSystem(pd);
    }

    private void HealthSystem(PlayerData pd)
    {

        
        if (pd.GetHP()==3)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0;
            ferimento.color = tempColor;
        }

        if (pd.GetHP() == 2)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.2f;
            ferimento.color = tempColor;
        }
        if (pd.GetHP() == 1)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.5f;
            ferimento.color = tempColor;
        }

        if (pd.GetHP() == 0)
        {
            var tempColor = ferimento.color;
            tempColor.a = 1f;
            ferimento.color = tempColor;
        }

    }

    

}
