using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmunitionShow : MonoBehaviour //sistema de munição, a munição funciona e diminui
//entretanto, o valor não aparece na tela, tentar ver um meio de aplicar isto
{

    public int municao;
    public bool atirando;
    public TMP_Text mostrarMunicao;
    
    // Start is called before the first frame update
    void Start()
    {
        municao = 80;
        atirando = false;
        //mostrarMunicao.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mostrarMunicao.text="Cargas: " + municao.ToString();
        if(Input.GetMouseButtonDown(0) && !atirando && municao > 0)
        {
               atirando = true;
               municao--;
               atirando = false;
        }
        
    }
}
