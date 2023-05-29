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

    public Camera cam;
    public GameObject projectile;
    public Transform RHFirePoint;
    public float projectileSpeed = 30;
    public float cadencia = 4;
    public float arcRange = 1;

    private Vector3 destination;
    private float contador_disparo;

    public PlayerData pd;

    public void PlayerAmmoSystem(TMP_Text mostrarMunicao, PlayerData pd)
    {
        this.municao = pd.getCargas();
        mostrarMunicao.text = "Cargas: " + this.municao;
        if (Input.GetMouseButtonDown(0) && !this.atirando && pd.getCargas() > 0)
        {
            this.atirando = true;
            this.atirando = false;
        }
    }

    public void CastingSystem()
    {
        if (Input.GetButtonDown("Fire1") && pd.getCargas() > 0)
        {
            contador_disparo = Time.time + 1 / cadencia;
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
