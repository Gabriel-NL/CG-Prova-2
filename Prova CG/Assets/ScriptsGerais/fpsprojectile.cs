using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fpsprojectile : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform RHFirePoint;
    public float projectileSpeed = 30;
    public float fireRate = 4;
    public float arcRange = 10;

    private Vector3 destination;
    private float tempotiro;

    public PlayerData pd;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.tempotiro > 0)
        {
            this.tempotiro -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && pd.getCargas() > 0)
            {
                tempotiro =  fireRate/10;
                pd.consumirCarga();

                ShootProjectile();
            }
        }
    }


    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        GameObject projectileObj;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
            //Debug.Log("Objeto atingido: " + hit.collider.gameObject.name);
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        projectileObj = Instantiate(projectile, RHFirePoint.position, Quaternion.identity);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - RHFirePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

}
