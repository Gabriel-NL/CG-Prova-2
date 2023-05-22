using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int vida;
    private int cargas;
    private static PlayerData instance;


    public PlayerData()
    {
        this.vida = 3;
        this.cargas = 5;
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
        this.cargas--;
    }

    public int getCargas()
    {
        return this.cargas;
    }
}

