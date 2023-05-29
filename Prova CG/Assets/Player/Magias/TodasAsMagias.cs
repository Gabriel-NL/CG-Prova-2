using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodasAsMagias : MonoBehaviour
{
    private List<Estrutura> lista_de_magias = new List<Estrutura>();
    
    public GameObject magia_inicial_vfx;
    public GameObject magia_1_vfx;
    public GameObject magia_2_vfx;
    public GameObject magia_3_vfx;

    //Instancia
    public static TodasAsMagias instance;

    public static TodasAsMagias Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TodasAsMagias();
            }
            return instance;
        }
    }


    public TodasAsMagias()
    {


        Estrutura magia_inicial = new Estrutura("Lumus", 2, 6, false, 4, 90, magia_inicial_vfx);
        lista_de_magias.Add(magia_inicial);
        
        Estrutura magia_1 = new Estrutura("Saxum", 10, 30, false, 4, 270, magia_1_vfx);
        lista_de_magias.Add(magia_1);

        Estrutura magia_2 = new Estrutura("Igneus", 50, 50, true, 1, 90, magia_2_vfx);
        lista_de_magias.Add(magia_2);

        Estrutura magia_3 = new Estrutura("Frigus", 10, 30, false, 8, 90, magia_3_vfx);
        lista_de_magias.Add(magia_3);
    }

    public Estrutura getMagia(int numeroMagia)
    {
        return lista_de_magias[numeroMagia];
    }


}
