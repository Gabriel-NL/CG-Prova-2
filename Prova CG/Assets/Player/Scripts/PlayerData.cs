using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //Scripts
    public TodasAsMagias tm;
    public UI classe_user_interface;

    //Variaveis
    private int vida;
    private int pontosDeDevocao;
    public bool UIatualizada;

    //Inventario
    private int magia_atual;
    private List<Estrutura> magias_equipadas = new();

    public void Inicializar()
    {
        this.magia_atual = 0;
        this.vida = 3;
        this.UIatualizada = false;

        this.tm.Initialize();

        magias_equipadas.Add(tm.getMagia(0));
        magias_equipadas[0].Cargas = 45;
        magias_equipadas.Add(tm.getMagia(1));
        magias_equipadas.Add(tm.getMagia(2));
        magias_equipadas.Add(tm.getMagia(3));
        
    }

    public void ConsumirCarga()
    {
        this.magias_equipadas[magia_atual].Cargas--; 
        classe_user_interface.AtualizarMunicao(this.magias_equipadas[magia_atual].Cargas);
    }

    public int GetCargas()
    {
        return this.magias_equipadas[magia_atual].Cargas;
    }

    public void RecarregarCargas() 
    {
        var cargas = magias_equipadas[magia_atual].MaxCargas;
        this.magias_equipadas[magia_atual].Cargas= cargas;
        classe_user_interface.AtualizarMunicao(cargas);
    }

    public void AcertouTiro(int quantia_pontos)
    {
        this.pontosDeDevocao += quantia_pontos;
        classe_user_interface.AtualizarPontos(quantia_pontos);
    }

    public int GetPontosDevocao()
    {
        return this.pontosDeDevocao;
    }

    public void TomouDano()
    {
        this.vida--;
        classe_user_interface.HealthSystem(this.vida);
    }



    public bool JogadorVivo() 
    {
        if (this.vida <= 0)
        {
            return false;
        }
        else
        {
            return true;

        }
    }

    public void SistemaDeTrocaDeMagias()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.magia_atual = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.magia_atual = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.magia_atual = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.magia_atual = 3;
        }
    }

    public void PegarMagiaNova(int id_magia) 
    {

        magias_equipadas.Add(tm.getMagia(id_magia));
    }


    public Estrutura GetDadosDaMagiaAtual()
    {

        try
        {
            classe_user_interface.AtualizarNomeMagia(magias_equipadas[this.magia_atual].Nome);
            return magias_equipadas[this.magia_atual];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log("Voce não tem outra magia! Erro de nome: " + ex);

            this.magia_atual = 0;
            return magias_equipadas[this.magia_atual];
        }
    }

}

