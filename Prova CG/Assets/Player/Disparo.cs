using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{



    //components
    private Camera cam;
    private Estrutura spell;
    private Transform RHFirePoint;
    public Animator animatorPlayer;
    

    //Variables
    private float cronometro;
    private Vector3 destination;

    //Values
    public float projectileSpeed = 30; 
    public float arcRange = 1;

    public void CastingSystem(Camera cam,Transform firePoint, PlayerData pd)
    {
        this.cam = cam;
        this.spell = pd.GetDadosDaMagiaAtual();
        this.RHFirePoint = firePoint;




        if (this.cronometro > 0)
        {
            this.cronometro -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && pd.GetCargas() > 0)
            {
                cronometro = 1f/ pd.GetDadosDaMagiaAtual().Cadencia;
                pd.ConsumirCarga();
                this.animatorPlayer.SetBool("shooting", true);
                HandleCasting();
            }
            else
            {
                //this.animatorPlayer.SetBool("shooting", false);
            }
        }
    }

    private void HandleCasting()
    {
        Ray ray = this.cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        GameObject projectileObj;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            destination = hit.point;
            //Debug.Log("Objeto atingido: " + hit.collider.gameObject.name);
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        projectileObj = Instantiate(this.spell.Vfx, this.RHFirePoint.position, Quaternion.identity);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - this.RHFirePoint.position).normalized * projectileSpeed;
        ProjetilCollider script = projectileObj.GetComponent<ProjetilCollider>();
        script.setTipo(this.spell);
        

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }





}
