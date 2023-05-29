using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public static Disparo instance;

    public static Disparo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Disparo();
            }
            return instance;
        }
    }

    public GameObject projectile;
    public Transform RHFirePoint;

    public float projectileSpeed = 30;
    public float cadencia = 4;
    public float arcRange = 1;

    private Vector3 destination;
    private float cronometro;
    private bool castingEnabled=false;

    void FireRateLimiter()
    {
        //Se o intervalor acabar, ele pode disparar
        if (this.cronometro > 0)
        {
            this.cronometro -= Time.deltaTime;
        }
        else
        {



        }
    }

    public void CastingSystem(PlayerData pd, Camera cam)
    {




        if (Input.GetButton("Fire1") && pd.getCargas() > 0)
        {
            cronometro = Time.time + 1 / cadencia;
            pd.consumirCarga();

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                destination = hit.point;
            else
                destination = ray.GetPoint(1000);

            ProjectileSystem(RHFirePoint);
        }
    }

    void ProjectileSystem(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }



}
