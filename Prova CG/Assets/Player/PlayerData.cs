using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //Variaveis
    private int vida;
    private int pontosDeDevocao;
    private int cargas;
    private bool playerVivo=true;

    //Inventario
    private int current_spell;
    private List<Estrutura> magias_equipadas = new List<Estrutura>();


    //Instancia
    public static PlayerData instance;


    public GameObject peanut;
    public PlayerData()
    {
        this.vida = 3;
        this.cargas = 500;
        
    }
    public static PlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerData();
            }
            return instance;
        }
    }

    public void consumirCarga()
    {
        this.magias_equipadas[current_spell].Cargas--;
    }

    public int getCargas()
    {
        return this.magias_equipadas[current_spell].Cargas;
    }

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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            this.cargas = 50;
            Destroy(other.gameObject);
        }
    }

    public void EquipamentoInicial(Estrutura magiaInicial)
    {

        magiaInicial.Cargas = 45;
        current_spell = 0;
        magias_equipadas.Add(magiaInicial);

    }

    public void SwitchSpells(int chosenSpell)
    {
        switch (chosenSpell)
        {
            case 0:
                this.current_spell = 0;
                break;
            case 1:
                this.current_spell = 1;
                break;
            default:
                break;
        }


        
        if ( magias_equipadas[current_spell] == null)
        {
            this.current_spell = 0;
            Debug.Log("Voce não tem outra magia!");

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

