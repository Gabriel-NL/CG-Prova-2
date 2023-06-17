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

    public void AtualizarMunicao(int cargas)
    {
        objetoMunicao.text = "Cargas: " + cargas;
    }

    public void AtualizarPontos(int pontos)
    {
        objetoPontos.text = pontos.ToString();
    }

    public void AtualizarNomeMagia(string nome)
    {
        objetoNome.text = nome;
    }

    public void AtualizarNomeMensagem(string mensagem)
    {
        objetoInteracao.text = mensagem;
    }

    public void AtualizarNumeroHorda(int numeroHorda)
    {
        objetoHorda.text =numeroHorda.ToString();
    }


    public void HealthSystem(int vida)
    {

        
        if (vida==3)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0;
            ferimento.color = tempColor;
        }

        if (vida==2)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.2f;
            ferimento.color = tempColor;
        }
        if (vida == 1)
        {
            var tempColor = ferimento.color;
            tempColor.a = 0.5f;
            ferimento.color = tempColor;
        }

        if (vida >= 0)
        {
            var tempColor = ferimento.color;
            tempColor.a = 1f;
            ferimento.color = tempColor;
        }

    }

    

}
