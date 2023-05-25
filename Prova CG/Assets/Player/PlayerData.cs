using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int vida;
    private int cargas;
    private bool playerVivo=true;
    public static PlayerData instance;


    public PlayerData()
    {
        this.vida = 3;
        this.cargas = 50;
        
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
        this.cargas= this.cargas - 1;
    }

    public int getCargas()
    {
        return this.cargas;
    }

    public void tomouDano()
    {
        this.vida=this.vida - 1;
        if (this.vida <= 0)
        {
            this.playerVivo = false;
        }

    }

    public int getHP()
    {
        return this.vida;
    }

    public bool playerDead() 
    {
        return playerVivo;
    }
}

