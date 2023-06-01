using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public static Disparo instance;
    public Animator animatorPlayer;

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
    //components
    public Camera cam;
    public GameObject projectile;//provisorio
    public Transform RHFirePoint;

    //Variables
    private float cronometro;
    private Vector3 destination;

    //Values
    public float projectileSpeed = 30; 
    public float arcRange = 1;

    public void CastingSystem(Camera cam, GameObject proj,Transform firePoint, PlayerData pd)
    {
        this.cam = cam;
        this.projectile = proj;
        this.RHFirePoint = firePoint;




        if (this.cronometro > 0)
        {
            this.cronometro -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && pd.getCargas() > 0)
            {
                int fireRate = pd.getCurrentSpellData().Cadencia;
                cronometro = 1f/fireRate;
                pd.consumirCarga();
                this.animatorPlayer.SetBool("shooting", true);
                HandleCasting();
            }
            else
            {
                this.animatorPlayer.SetBool("shooting", false);
            }
        }
    }

    private void HandleCasting()
    {
        Ray ray = this.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
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

        projectileObj = Instantiate(this.projectile, this.RHFirePoint.position, Quaternion.identity);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - this.RHFirePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

    public void ChangeSpells(PlayerData pd)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pd.SwitchSpells(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pd.SwitchSpells(1);
        }
    }



}
