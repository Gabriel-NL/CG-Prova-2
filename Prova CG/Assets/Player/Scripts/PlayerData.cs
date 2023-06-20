using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class PlayerData : MonoBehaviour
{

    //Scripts
    public TodasAsMagias tm;
    public UI classe_interface_usuario;
    public HandSymbol simbol;

    //Variaveis
    private int vida;
    private int pontosDeDevocao;

    //Inventario
    private int magia_atual;
    private List<Estrutura> magias_equipadas = new();

    public void Inicializar()
    {
        
        this.magia_atual = 0;
        this.vida = 3;
        this.classe_interface_usuario.HealthSystem(this.vida);
        this.classe_interface_usuario.AtualizarMensagem("");

        this.tm.Initialize();

        magias_equipadas.Add(tm.getMagia(0));
        magias_equipadas[0].Cargas = 45;

        classe_interface_usuario.AtualizarMunicao(magias_equipadas[magia_atual].Cargas);
        this.simbol.AtualizarMaterial(this.magias_equipadas[ magia_atual].tatuagem);

        
    }

    public void ConsumirCarga()
    {
        this.magias_equipadas[magia_atual].Cargas--; 
        classe_interface_usuario.AtualizarMunicao(this.magias_equipadas[magia_atual].Cargas);
    }

    public int GetCargas()
    {
        return this.magias_equipadas[magia_atual].Cargas;
    }

    public void RecarregarCargas() 
    {
        var cargas = magias_equipadas[magia_atual].MaxCargas;
        this.magias_equipadas[magia_atual].Cargas= cargas;
        classe_interface_usuario.AtualizarMunicao(cargas);
    }

    public void AdicionarPontosDevocao(int quantia_pontos)
    {
        this.pontosDeDevocao += quantia_pontos;
        classe_interface_usuario.AtualizarPontos(this.pontosDeDevocao);
    }

    public int GetPontosDevocao()
    {
        return this.pontosDeDevocao;
    }

    public void ConsumirPontosDevocao(int custo)
    {
        this.pontosDeDevocao-=custo;
        classe_interface_usuario.AtualizarPontos(this.pontosDeDevocao);
    }
    public void TomouDano()
    {
        this.vida--;
        classe_interface_usuario.HealthSystem(this.vida);
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
        if (Input.GetKeyDown(KeyCode.Alpha2) && magias_equipadas.Count>1)
        {
            this.magia_atual = 1;
        }
        classe_interface_usuario.AtualizarMunicao(magias_equipadas[ magia_atual].Cargas);

    }

    public void PegarMagiaNova(int id_magia) 
    {        
        if (magias_equipadas.Count<2)
        {
            Debug.Log("Adicionando"+ tm.getMagia(id_magia).tatuagem);
            magias_equipadas.Add(tm.getMagia(id_magia));
        }
        else
        {
            if (magias_equipadas.Contains(tm.getMagia(id_magia)))
            {
                Debug.Log("Ja tem a magia");
                magias_equipadas[magia_atual].Cargas = magias_equipadas[magia_atual].MaxCargas;
            }
            else
            {
            Debug.Log("Alterando");
                magias_equipadas[magia_atual] = tm.getMagia(id_magia);
            }

        }

    }


    public Estrutura GetDadosDaMagiaAtual()
    {

        try
        {
            classe_interface_usuario.AtualizarNomeMagia(magias_equipadas[this.magia_atual].Nome);
            simbol.AtualizarMaterial(this.magias_equipadas[magia_atual].tatuagem);
            return magias_equipadas[this.magia_atual];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log("Voce não tem outra magia! Erro de nome: " + ex);

            this.magia_atual = 0;
            simbol.AtualizarMaterial(this.magias_equipadas[magia_atual].tatuagem);
            return magias_equipadas[this.magia_atual];
        }
    }

    public void Debugando()
    {
        classe_interface_usuario.HealthSystem(this.vida);
    }

}

