using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UI : MonoBehaviour
{
    //Componentes
    public TMP_Text objetoMunicao;
    public TMP_Text objetoPontos;
    public TMP_Text objetoHorda;
    public TMP_Text objetoNome;
    public TMP_Text objetoInteracao;
    public Image ferimento;

    //Debug
    public float controle=0.1f;

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

    public void AtualizarMensagem(string mensagem)
    {
        objetoInteracao.text = mensagem;
    }

    public void AtualizarNumeroHorda(int numeroHorda)
    {
        objetoHorda.text =numeroHorda.ToString();
    }


    public void HealthSystem(int vida)
    {
                Color tempColor = ferimento.color;

        switch (vida)
        {

            case 3:
                tempColor.a = 0f;
                ferimento.color = tempColor;

                break;

            case 2:
                tempColor.a = 0.2f;
                ferimento.color = tempColor;

                break;
            case 1:
                tempColor.a = 0.5f;
                ferimento.color = tempColor;

                break;

            default:
                Debug.Log("Ops");
                tempColor.a = 1f;
                ferimento.color = tempColor;

                break;
        }


    }

    

}
