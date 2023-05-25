using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenBot : MonoBehaviour
{

    public Animator animator;
    public bool grounded;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "GroundTag")
        {
            grounded = true;
            //animator.applyRootMotion = true;

        }
    }
    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "GroundTag")
        {
            grounded = false;
            animator.applyRootMotion = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.down * 300);
    }


}
