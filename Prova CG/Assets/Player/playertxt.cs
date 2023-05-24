using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertxt : MonoBehaviour
{
    public playerpoints score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            score.AddScore(100);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            score.AddScore(50);
        }
    }
}
