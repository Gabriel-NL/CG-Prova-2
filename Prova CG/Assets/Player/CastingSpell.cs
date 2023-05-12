using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : MonoBehaviour
{

    public GameObject efeitoMagia, efeitoAtingido;
    public Transform pivotDisparo;
    public AudioSource somMagia;
    public float danoMagia=2;

    private Camera cam;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        cam= Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Conjurar(Convert.ToBoolean(Input.GetMouseButton(0)));

    }

    void Conjurar(bool c)
    {
        anim.SetBool("Casting", c);
        efeitoMagia.SetActive(c);

        if (c)
        {
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(
                cam.transform.position,
                cam.transform.forward, out hit,Mathf.Infinity,
                LayerMask.GetMask("Inimigos")
                );
            //hit.collider.gameObject.GetComponent<Fallen>().vida -= danoMagia;
            /*
            Instantiate(efeitoAtingido, hit.point,
            hit.collider.gameObject.transform.rotation,
            hit.collider.gameObject.transform);
             */

        }
    }
}
