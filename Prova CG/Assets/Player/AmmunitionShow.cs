using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmunitionShow : MonoBehaviour //sistema de munição, a munição funciona e diminui
//entretanto, o valor não aparece na tela, tentar ver um meio de aplicar isto
{

    public int municao;
    public bool atirando;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && !atirando && municao > 0)
        {
               atirando = true;
               municao--;
               atirando = false;
        }
        
    }
}
