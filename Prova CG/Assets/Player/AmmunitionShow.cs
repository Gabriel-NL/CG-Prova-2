using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmunitionShow : MonoBehaviour
{
    public PlayerData pd;
    private int cargas;
    public bool atirando;
    public TMP_Text mostrarMunicao;
    
    void Start()
    {
        atirando = false;
    }

    void Update()
    {
        cargas = pd.getCargas();
        mostrarMunicao.text="Cargas: " + cargas.ToString();
        if(Input.GetMouseButtonDown(0) && !atirando && cargas > 0)
        {
                atirando = true;
                pd.consumirCarga();
                atirando = false;
        }
        
    }
}
