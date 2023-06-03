using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodasAsMagias : MonoBehaviour
{
    private List<Estrutura> lista_de_magias = new();

    [SerializeField] public GameObject magia_inicial_vfx;
    [SerializeField] public GameObject lumus_vfx;
    [SerializeField] public GameObject igneus_vfx;
    [SerializeField] public GameObject frigus_vfx;
    [SerializeField] public GameObject saxum_vfx;

    public void Initialize()
    {
        this.lumus_vfx = GameObject.Find("vfx_lumus");
        this.igneus_vfx =  GameObject.Find("vfx_igneus");
        this.frigus_vfx = GameObject.Find("vfx_frigus");
        this.saxum_vfx = GameObject.Find("vfx_saxum");

        Estrutura magia_1 = new Estrutura("Lumus", 2, 6, false, 4, 90,90, lumus_vfx);
        lista_de_magias.Add(magia_1);


        Estrutura magia_2 = new Estrutura("Igneus", 50, 50, true, 1, 90,90, igneus_vfx);
        lista_de_magias.Add(magia_2);

        Estrutura magia_3 = new Estrutura("Frigus", 10, 30, false, 8, 90,90, frigus_vfx);
        lista_de_magias.Add(magia_3);
        //Debug.Log(frigus_vfx.name);

        Estrutura magia_4 = new Estrutura("Saxum", 10, 30, false, 4, 270,270, saxum_vfx);
        lista_de_magias.Add(magia_4);      
        
    }

    public Estrutura getMagia(int numeroMagia)
    {
        return lista_de_magias[numeroMagia];
    }


}
