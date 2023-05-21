using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int vida;
    private int cargas;

    private PlayerData[] dadosDoJogador = new PlayerData[1];

    void Start()
    {
        dadosDoJogador[0] = new PlayerData
        {
            vida = 3,
            cargas = 5
        };
    }

    public void consumirCarga()
    {
        dadosDoJogador[0].cargas--;
    }

    public int getCargas()
    {
        return dadosDoJogador[0].cargas;
    }
}

