using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public GameObject impactoVFX;
    private bool collided;

    void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag != "Ground")
        {
            var impact = Instantiate(impactoVFX, c.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(impact, 2);
        }
    }
}
