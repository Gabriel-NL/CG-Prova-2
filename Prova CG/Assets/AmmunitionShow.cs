using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionShow : MonoBehaviour
{

    public int municao;
    public bool atirando;
    public text ammunitionShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammunitionShow.text = municao.ToString();
        if(Input.GetMouseButtonDown(0) && !atirando && municao > 0)
        {
               atirando = true;
               municao--;
               atirando = false;
        }
        
    }
}
