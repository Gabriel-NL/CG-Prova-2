using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmunitionShow : MonoBehaviour //sistema de munição, a munição funciona e diminui
//entretanto, o valor não aparece na tela, tentar ver um meio de aplicar isto
{
    public PlayerData pd;
    private int cargas;
    public bool atirando;
    public TMP_Text mostrarMunicao;
    
    // Start is called before the first frame update
    void Start()
    {
        atirando = false;
        //mostrarMunicao.GetComponent<Text>();
    }

    // Update is called once per frame
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
