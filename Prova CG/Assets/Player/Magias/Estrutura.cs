using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrutura
{
    public string Nome { get; set; }
    public int Dano { get; set; }
    public int DanoNaCabeca { get; set; }
    public bool DanoEmArea { get; set; }
    public int Cadencia { get; set; }
    public int Cargas { get; set; }

    public GameObject Vfx { get; set; }

    public Estrutura(string nome,int dano, int danoNaCabeca, bool danoEmArea, int cadencia, int usos, GameObject vfx)
    {
        this.Nome = nome;
        this.Dano = dano;
        this.DanoNaCabeca = danoNaCabeca;
        this.DanoEmArea = danoEmArea;
        this.Cadencia = cadencia;
        this.Cargas = usos;
        this.Vfx = vfx;

    }

    

}
