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
    private bool playerVivo=true;

    //Inventario
    private int current_spell;
    private List<Estrutura> magias_equipadas = new List<Estrutura>();


    

    public GameObject peanut;

    public void initialize()
    {
        this.current_spell = 0;
        this.vida = 3;
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


    public void consumirCarga()
    {
        this.magias_equipadas[current_spell].Cargas--;
    }

    public int getCargas()
    {
        return this.magias_equipadas[current_spell].Cargas;
    }

    public void recarregarCargas() { this.magias_equipadas[current_spell].Cargas=tm.getMagia(current_spell).Cargas; }

    public void acertouTiro(int quantia_pontos)
    {
        this.pontosDeDevocao = this.pontosDeDevocao + quantia_pontos;
    }
    public int getPontosDevocao()
    {
        return this.pontosDeDevocao;
    }

    public void tomouDano()
    {
        this.vida = this.vida - 1;
        Debug.Log("Vida atual: "+ this.vida);
    }

    public int getHP()
    {
        return this.vida;
    }

    public bool playerState() 
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

    public void SwitchSpells()
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

    public Estrutura getCurrentSpellData()
    {

        try
        {
            return magias_equipadas[this.current_spell];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log("Voce não tem outra magia!");
            this.current_spell = 0;
            return magias_equipadas[this.current_spell];
        }
    }

}

