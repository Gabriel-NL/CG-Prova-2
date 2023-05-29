using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int vida;
    private int pontosDeDevocao;
    private int cargas;
    private bool playerVivo=true;
    public static PlayerData instance;
    public GameObject peanut;


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
        PlayerData.Instance.cargas += 50;
        Destroy(other.gameObject);
    }
}


}

