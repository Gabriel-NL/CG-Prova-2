using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercrouch : MonoBehaviour
{
public float crouchHeight = 0.5f;
public float crouchSpeed = 5f;

private float originalHeight;
private bool agachado = false;


    // Start is called before the first frame update
    void Start()
    {
        originalHeight = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!agachado)
            {
                transform.localScale = new Vector3(transform.localScale.x,crouchHeight,transform.localScale.z);
                agachado = true;            
            }
            else
            {
                RaycastHit hit;
                if(!Physics.Raycast(transform.position, Vector3.up, out hit,originalHeight))
                {
                    transform.localScale = new Vector3(transform.localScale.x, originalHeight, transform.localScale.z);
                    agachado= false;
                }
            }
        }
    }
}
