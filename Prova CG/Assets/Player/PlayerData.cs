using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //Scripts
    public TodasAsMagias tm;

    //Variaveis
    private int vida;
    private int pontosDeDevocao;
    public bool UIatualizada;

    //Inventario
    private int current_spell;
    private List<Estrutura> magias_equipadas = new();

    public void Inicializar()
    {
        this.current_spell = 0;
        this.vida = 3;
        this.UIatualizada = false;

        this.tm.Initialize();

        magias_equipadas.Add(tm.getMagia(0));
        magias_equipadas[0].Cargas = 45;
        magias_equipadas.Add(tm.getMagia(1));
        magias_equipadas.Add(tm.getMagia(2));
        magias_equipadas.Add(tm.getMagia(3));

    }

    public PlayerData()
    {
  
    }



    public void ConsumirCarga()
    {
        this.magias_equipadas[current_spell].Cargas--;
    }

    public int GetCargas()
    {
        return this.magias_equipadas[current_spell].Cargas;
    }

    public void RecarregarCargas() 
    {
        this.magias_equipadas[current_spell].Cargas= magias_equipadas[current_spell].MaxCargas; 
    }

    public void AcertouTiro(int quantia_pontos)
    {
        this.pontosDeDevocao += quantia_pontos;
    }
    public int GetPontosDevocao()
    {
        return this.pontosDeDevocao;
    }

    public void TomouDano()
    {
        this.vida--;  
        
    }

    public int GetHP()
    {
        return this.vida;
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
            this.current_spell = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.current_spell = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.current_spell = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.current_spell = 3;
        }

    }

    public Estrutura GetCurrentSpellData()
    {

        try
        {
            return magias_equipadas[this.current_spell];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log("Voce não tem outra magia! Erro de nome: " + ex);

            this.current_spell = 0;
            return magias_equipadas[this.current_spell];
        }
    }

}

